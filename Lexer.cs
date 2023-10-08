/*
 * Subhash Muthu's
 * Sublang
 *
 * The Lexer
 *
 */


using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace Sublang{

    public class Lexer{

        private static bool IsLexical(char schar){
            return Array.IndexOf(Keywords.KEYWORDS, schar) >= 0;
        }
        

        public static Tuple<TkType, char?[]>[] Tokenize(string source){

            char?[] noVal = {null};

            Tuple<TkType, char?[]>[] TokenArray = Array.Empty<Tuple<TkType,char?[]>>();
            
            while(source.Length > 0){
                if(IsLexical(source[0])){
                    char lex = source[0];
                    source.Remove(0);
                    TokenArray.Append(Tuple.Create((TkType)lex, noVal));
                }else if(source[0] == '"'){
                    char?[] value = Array.Empty<char?>();
                    do{
                        value.Append(source[0]);
                        source.Remove(0);
                    }while(source[0] != '"');
                    TokenArray.Append(Tuple.Create(TkType.String, value));
                }else if(char.IsDigit(source[0])){
                    char?[] value = Array.Empty<char?>();
                    do{
                        value.Append(source[0]);
                        source.Remove(0);
                    }while(char.IsDigit(source[0]));
                    TokenArray.Append(Tuple.Create(TkType.Number, value));
                }else if(source[0] == '$'){
                    char?[] value = Array.Empty<char?>();
                    do{
                        value.Append(source[0]);
                        source.Remove(0);
                    }while(!IsLexical(source[0]));
                    TokenArray.Append(Tuple.Create(TkType.Identifier, value));
                }
                TokenArray.Append(Tuple.Create(TkType.Error, noVal));
                
            }
            TokenArray.Append(Tuple.Create(TkType.Whitespace, noVal));

            return TokenArray;
        }
    }
}