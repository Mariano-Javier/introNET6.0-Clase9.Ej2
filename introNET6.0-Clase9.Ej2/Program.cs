Console.WriteLine("          - Bingo Aleatorio -  Intro NET 6.0 -");
Console.WriteLine("Ingrese la cantidad de cartones que desea generar: ");
int cartones = int.Parse(Console.ReadLine());
for (int w = 0;w < cartones; w++)
{
    //Matriz y vector con los que se generarán los valores aleatorios.
    int[,] carton = new int[3, 9];
    int[] vectorNuevo = new int[3];

    Random aleatorio = new Random();

    int numero1 = 1;
    int numero2 = 10;
    int m = 0;

    for (int i = 0; i < 9; i++)
    {
        //Crear el vector que forma las columnas
        bool validez = false;
        int valorAVerificar;
        for (int t = 0; t < 3; t++)
        {
            do
            {
                valorAVerificar = aleatorio.Next(numero1, numero2);

                for (int p = 0; p < vectorNuevo.Length; p++)
                {
                    if (vectorNuevo[p] == valorAVerificar)
                    {
                        validez = true;
                        break;
                    }
                    else
                    {
                        validez = false;
                    }
                }
            }
            while (validez);

            vectorNuevo[t] = valorAVerificar;
        }
        //Ordenar vector
        Array.Sort(vectorNuevo);

        //Asignar valores por columna a la matriz
        for (int r = 0; r < 3; r++)
        {
            carton[r, m] = vectorNuevo[r];
        }
        m++;

        //Incrementar el valor de los limites numericos
        numero1 += 10;
        numero2 += 10;
    }

    //Generar un vector con 4 valores random del 0 al 8 para la fila 1.
    int[] vectorRandomF1 = new int[4];
    int reemplazoF1;
    bool verificarReF1 = false;

    for (int i = 0; i < vectorRandomF1.Length; i++)
    {
        vectorRandomF1[i] = 99; //Le asigno valores distintos a 0 para evitar que el 0 no quede filtrado.
    }

    for (int i = 0; i < vectorRandomF1.Length; i++)
    {
        do
        {
            reemplazoF1 = aleatorio.Next(0, 9);

            for (int j = 0; j < vectorRandomF1.Length; j++)
            {


                if (vectorRandomF1[j] == reemplazoF1)
                {
                    verificarReF1 = true;
                    break;
                }
                else
                {
                    verificarReF1 = false;
                }
            }
        }
        while (verificarReF1);

        vectorRandomF1[i] = reemplazoF1;
    }

    Array.Sort(vectorRandomF1);

    //Generar un vector con 4 valores random del 0 al 8 para la fila 2.
    int[] vectorRandomF2 = new int[4];
    int reemplazoF2;
    bool verificarReF2 = false;

    for (int i = 0; i < vectorRandomF2.Length; i++)
    {
        do
        {
            do
            {
                reemplazoF2 = aleatorio.Next(0, 9);
            }
            while (vectorRandomF1[0] == reemplazoF2 || vectorRandomF1[1] == reemplazoF2 || vectorRandomF1[2] == reemplazoF2 || vectorRandomF1[3] == reemplazoF2);//Limito la elección a 4 valores diferentes a los 4 que ya estan en el primer vector.
            
            for (int j = 0; j < vectorRandomF2.Length; j++)
            {
                if (vectorRandomF2[j] == reemplazoF2)
                {
                    verificarReF2 = true;
                    break;
                }
                else
                {
                    verificarReF2 = false;
                }
            }
        }
        while (verificarReF2);

        vectorRandomF2[i] = reemplazoF2;
    }

    Array.Sort(vectorRandomF2);

    //generar el valor faltante (ya que en los primeros 2 vectores se generaron 8 valores de los 9 posibles, esto garantiza que todos los espacios sean usados).
    int valorSolitario;
    do
    {
        valorSolitario = aleatorio.Next(0, 9);
    }
    while (vectorRandomF1[0] == valorSolitario || vectorRandomF1[1] == valorSolitario || vectorRandomF1[2] == valorSolitario || vectorRandomF1[3] == valorSolitario || vectorRandomF2[0] == valorSolitario || vectorRandomF2[1] == valorSolitario || vectorRandomF2[2] == valorSolitario || vectorRandomF2[3] == valorSolitario);

    //Generar un vector con 4 valores random del 0 al 8 para la fila 3 Verificando los números duplicados en los vectores 1 y 2.
    int[] vectorRandomF3 = new int[4];
    int reemplazoF3;
    bool verificarReF3 = false;

    for (int i = 0; i < vectorRandomF3.Length; i++)
    {
        vectorRandomF3[i] = 99;
    }

    vectorRandomF3[0] = valorSolitario; //Asigno el valor que quedo fuera de la selección de los primeros 2 vectores.

    for (int i = 1; i < vectorRandomF3.Length; i++)
    {
        do
        {
            do
            {
                reemplazoF3 = aleatorio.Next(0, 9);
            }
            while (reemplazoF3 == valorSolitario);// Para que genere cualquier valor menos el que ya esta asignado en la primera posición y no se repita.

            for (int j = 1; j < vectorRandomF3.Length; j++)
            {

                if (vectorRandomF3[j] == reemplazoF3)
                {
                    verificarReF3 = true;
                    break;
                }
                else
                {
                    verificarReF3 = false;
                }
            }
        }
        while (verificarReF3);

        vectorRandomF3[i] = reemplazoF3;
    }

    Array.Sort(vectorRandomF3);

    //Convertir matriz int a string.
    string[,] cartonFinal = new string[3, 9];

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            cartonFinal[i, j] = carton[i, j].ToString();
        }
    }

    //Agrego 0 a los primeros valores de la fila 1 para que la impresión quede pareja.
    for (int i = 0; i < 3; i++)
    {
        cartonFinal[i, 0] = "0" + cartonFinal[i, 0];
    }

    //Asigna valores vacios a las posiciones random que se generaron en los vectores del 1 al 3.
    for (int i = 0; i < 4; i++)
    {
        cartonFinal[0, vectorRandomF1[i]] = "  ";
        cartonFinal[1, vectorRandomF2[i]] = "  ";
        cartonFinal[2, vectorRandomF3[i]] = "  ";
    }

    //imprime matriz string
    Console.WriteLine($"       - Cartón Aleatorio #{w+1} -  Bingo NET 6.0 -");
    Console.WriteLine("========================================================");
    for (int i = 0; i < 3; i++)
    {
        Console.Write("|");
        for (int t = 0; t < 9; t++)
        {
            Console.Write("| " + cartonFinal[i, t] + " |");
        }
        Console.Write("|");
        Console.WriteLine();
    }
    Console.WriteLine("========================================================");
    Console.WriteLine();
}