using System;
using System.Threading;

class isPrimoConc
{
    public class Calcular{
        long cuenta=0;
        public void CalcularDivisores(Valores valor){
            cuenta = Divisores.numOfPosDivisors(valor.getNum(), valor.getFrom(), valor.getTo());
        }

        public long getCuenta(){
            return cuenta;
        }
    }
    public static long numOfPosDivisors(long num) {
        long count = 1;
        long numreal = num / 2;
        long ini = 0;
        int numThreads = 4;
        long fin = (numreal / numThreads);
        Calcular calcular = new Calcular();
        Thread[] calculos = new Thread[numThreads];
        
        for (int i = 0; i < numThreads; i++) {
            if (i == numThreads-1) {
                fin = ((numreal - ini) + ini);
            }
            Valores numero = new Valores(num,ini,fin);
            calculos[i] = new Thread(new ParameterizedThreadStart(calcular.CalcularDivisores(numero)));
            ini = fin + 1;
            fin = ((ini + (numreal/ numThreads)) -1);
            
        }
        
        foreach (var calculo in calculos){
            calculo.Start();
        }
        
        foreach (var calculo in calculos){
            try{
                calculo.Join();

                //count += calculo;
            }catch{
            
            }
        }
        return count;
    }
    
}