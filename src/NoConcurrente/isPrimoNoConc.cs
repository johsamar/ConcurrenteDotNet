using System;
using src;

namespace src
{
    class isPrimoNoConc
    {
    public static bool esPrimo(long num){
        if(Divisores.numOfPosDivisors(num) == 2){
            return true;
        }
        return false;
    }

}
}