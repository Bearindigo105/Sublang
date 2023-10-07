
export enum TokenType{
    Number,
    Identifier,
    Equals,
    OpenParen, 
    CloseParen,
    BinaryOperator,
    Let,
}

export interface Token{
    value: string,
    type: TokenType,
}

function token(value = "", type: TokenType): Token {
    return { value, type};
}

function isAlpha(src: string){
    return src.toUpperCase() != src.toLowerCase();
}

function isInt(src: string){
    const c = src.charCodeAt(0);
    const bounds = ['0'.charCodeAt(0), '9'.charCodeAt(9)]
    return (c >= bounds[0] && c <= bounds[1]);
}

export function tokenize(sourceCode: string): Token[]{
    const tokens = new Array<Token>();
    const src = sourceCode.split("");
    
    //Build each token until end of file
    while(src.length > 0){
        if(src[0] == '('){
            tokens.push(token(src.shift(), TokenType.OpenParen))
        }
        switch(src[0]){
            case '(': 
                tokens.push(token(src.shift(), TokenType.OpenParen))
                break;
            case ')': 
                tokens.push(token(src.shift(), TokenType.CloseParen))
                break;
            case '+': case '-': case '*': case '/':
                tokens.push(token(src.shift(), TokenType.BinaryOperator))
                break;
            case '=':
                tokens.push(token(src.shift(), TokenType.Equals))
                break;
            default:
                //handle multi-char tokens
                if(isInt(src[0])){
                    //TODO MULTI-CHAR TOKENS
                }
        }
    }


    return tokens;
}