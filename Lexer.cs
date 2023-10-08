/*
 * Subhash Muthu's
 * Sublang
 *
 * The Lexer
 *
 */


namespace Sublang{

    public class Lexer{

        private static bool IsLexical(char schar){
            return Array.IndexOf(Keywords.KEYWORDS, schar) > -1;
        }

        public static Tuple<TkType, char?[]>[] Tokenize(List<char> source){

            char?[] noVal = {null};

            List<Tuple<TkType, char?[]>> TokenList = new List<Tuple<TkType, char?[]>>();
            
            while(source.Count > 0){

                if(IsLexical(source[0])){
                
                    char lex = source[0];
                    source.RemoveAt(0);
                
                    TokenList.Add(Tuple.Create((TkType)lex, noVal));
                
                }else if(source[0] == '"'){
                
                    char?[] value = Array.Empty<char?>();
                
                    do{
                
                        value.Append(source[0]);
                        source.RemoveAt(0);
                
                    }while(source[0] != '"');
                
                    TokenList.Add(Tuple.Create(TkType.String, value));
                }else if(char.IsDigit(source[0])){
                
                    char?[] value = Array.Empty<char?>();
                
                    do{
                
                        value.Append(source[0]);
                        source.RemoveAt(0);
                
                    }while(char.IsDigit(source[0]));
                
                    TokenList.Add(Tuple.Create(TkType.Number, value));
                }else if(source[0] == '$'){
                
                    char?[] value = Array.Empty<char?>();
                
                    do{
                
                        value.Append(source[0]);
                        source.RemoveAt(0);
                
                    }while(!IsLexical(source[0]));
                
                    TokenList.Add(Tuple.Create(TkType.Identifier, value));
                }
                TokenList.Add(Tuple.Create(TkType.Error, noVal));
            }
            TokenList.Add(Tuple.Create(TkType.Whitespace, noVal));

            return TokenList.ToArray();
        }
    }
}