/*
 * Subhash Muthu's
 * Sublang
 *
 * Enums used in the compiler
 *
 */


namespace Sublang{

    public enum TkType{
            //Single Char
            BinaryOp,
            OpenPar,
            ClosePar,
            Declaration,
            Mutator,
            IfStatement,
            WhileStatement,
            JumpStatement,
            Whitespace,
            ArrayOpen,
            ArrayClose,
            Encapsulator,
            BooleanOp,
            EGLThanOp,
            Separator,
            Error,
            //Multi Char
            Identifier,
            Number,
            String
        }

    public readonly struct Keywords{
        public readonly static char[] KEYWORDS = {
            //whitespace
            '#',
            '\n',
            '\t',
            ' ',
            //declaration
            'l',
            //mutator
            '*',
            //if statement
            '?',
            //encapsulator
            ':',
            //while statement
            'w',
            //jump
            'j',
            //parenthesis
            '(',
            ')',
            //array
            '[',
            ']',
            //binary operators
            '+',
            '-',
            '*',
            '/',
            //boolean operators
            '&',
            '|',
            '!',
            //equals greater less than operators
            '>',
            '<',
            '=',
            //separator
            ';'
        };
    }

        

}
