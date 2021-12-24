using Antlr4.Runtime;

namespace LabaOOP1
{
    public class ExcelClass
    {
        public ExcelClass(string exp) {
            lexer = Lexer(new AntlrInputStream(exp));
        }
        public ExcelClass() {}
        public TestExcelLexer lexer;
        public CommonTokenStream tokens;
        public TestExcelParser parser;

        public TestExcelLexer Lexer(AntlrInputStream stream) => new TestExcelLexer(stream);
        public CommonTokenStream Tokenizer(TestExcelLexer lexer) => new CommonTokenStream(lexer);
        public TestExcelParser Parser(CommonTokenStream token) => new TestExcelParser(token);

        public double Evaluate(string expression)
        {
            var v = new AntlrInputStream(expression);
            lexer = Lexer(v);

            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            tokens = Tokenizer(lexer);
            parser = Parser(tokens);

            var tree = parser.compileUnit();
            var visitor = new TestExcelVisitor();
            return visitor.Visit(tree);
        }
    }
}
