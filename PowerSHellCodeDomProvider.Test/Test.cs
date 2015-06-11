using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation.Language;
using ICSharpCode.NRefactory.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerShellCodeDomProvider.Test
{
    [TestClass]
    [DeploymentItem(ExpectationsFile)]
    [DeploymentItem(TestDataFile)]
    public class Test
    {
        private static Dictionary<string, string> Expectations;
        private static Dictionary<string, string> TestData;

        public const string ExpectationsFile = "Expectations.ps1";
        public const string TestDataFile = "TestData.cs";

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Token[] psTokens;
            ParseError[] psErrors;
            var ast = Parser.ParseFile(Path.Combine(context.DeploymentDirectory, ExpectationsFile), out psTokens, out psErrors);
            var items = ast.EndBlock.FindAll(m => m is AssignmentStatementAst, false);
            Expectations = new Dictionary<string, string>();

            foreach (AssignmentStatementAst item in items)
            {
                var variableExpression = item.Left as VariableExpressionAst;
                var scriptBlockAst = item.Right.Find(m => m is ScriptBlockAst, true) as ScriptBlockAst;
                if (variableExpression != null && scriptBlockAst != null)
                {
                    Expectations.Add(variableExpression.VariablePath.UserPath, scriptBlockAst.Extent.ToString().Trim('}', '{').Trim());
                }
            }

            TestData = new Dictionary<string, string>();

            var parser = new CSharpParser();
            var syntaxTree = parser.Parse(File.ReadAllText(Path.Combine(context.DeploymentDirectory, TestDataFile)));
            foreach (NamespaceDeclaration namespaceDeclaration in syntaxTree.Members.Where(m => m is NamespaceDeclaration))
            {
                TestData.Add(namespaceDeclaration.FullName, namespaceDeclaration.ToString());
            }
        }

        [TestMethod]
        public void RunTest()
        {
            foreach (var testData in TestData)
            {
                if (!Expectations.ContainsKey(testData.Key))
                {
                    Assert.Fail("Missing expectations for " + testData.Key);
                }

                Assert.AreEqual(Expectations[testData.Key], CSharpToPowerShell(testData.Value).Trim());
            }
        }

        private static string CSharpToPowerShell(string csharp)
        {
            CSharpParser parser = new CSharpParser();
            SyntaxTree syntaxTree = parser.Parse(csharp);
            CodeDomConvertVisitor visitor = new CodeDomConvertVisitor();
            var codeObject = syntaxTree.AcceptVisitor(visitor);

            var stringWriter = new StringWriter();
            var powerShellProvider = new PowerShellCodeDomProvider();
            powerShellProvider.GenerateCodeFromCompileUnit(codeObject as CodeCompileUnit, stringWriter, new CodeGeneratorOptions());

            return stringWriter.ToString();
        }
    }
}
