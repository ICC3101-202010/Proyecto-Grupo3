using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Netify
{

    [Serializable]
    class MatrizSeguirCantantes
    {
        public List<List<bool>> matrizSeguirCantantes;

        public MatrizSeguirCantantes()
        {
            //Al inicializar la matriz, checkeo si esta el archivo "FollowArtistMatrix.bin".

            //Si esta, simplemente la cargo. 
            if (File.Exists("FollowArtistMatrix.bin") == true)
            {
                IFormatter formatter2 = new BinaryFormatter();
                Stream stream2 = new FileStream("FollowArtistMatrix.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                try
                {
                    List<List<bool>> matrizCargada = (List<List<bool>>)formatter2.Deserialize(stream2);

                    this.matrizSeguirCantantes = matrizCargada;

                    stream2.Close();

                }

                //Si esta vacia, guardo. 

                catch (SerializationException)
                {
                    List<List<bool>> matrizCargada = new List<List<bool>>();
                    //Lleno de false para no tener problemas con los indices.
                    for (int i = 0; i < 250; i++)
                    {
                        //Lleno columna de falses.
                        List<bool> iEsima = new List<bool>();
                        for (int j = 0; j < 250; j++)
                        {
                            iEsima.Add(false);
                        }

                        //Agrego fila a matriz. 
                        matrizCargada.Add(iEsima);
                    }
                    //Lleno de false para no tener problemas con los indices.
                    this.matrizSeguirCantantes = matrizCargada;
                    formatter2.Serialize(stream2, matrizCargada);
                    stream2.Close();
                    throw;
                }
            }


            //Si no esta archivo, creo nueva matriz y guardo en archivo. 
            if (File.Exists("FollowArtistMatrix.bin") == false)
            {

                List<List<bool>> matrizCargada = new List<List<bool>>();


                //Lleno de false para no tener problemas con los indices.
                for (int i = 0; i < 250; i++)
                {
                    //Lleno columna de falses.
                    List<bool> iEsima = new List<bool>();
                    for (int j = 0; j < 250; j++)
                    {
                        iEsima.Add(false);
                    }

                    //Agrego fila a matriz. 
                    matrizCargada.Add(iEsima);
                }
                this.matrizSeguirCantantes = matrizCargada;


                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("FollowArtistMatrix.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                formatter.Serialize(stream, matrizCargada);
                stream.Close();
            }



        }

        public void seguirCantante(int userID, int singerID)
        {
            //Cambio var de estado en matriz.
            matrizSeguirCantantes[userID][singerID] = true;

            //Serializo y guardo. 

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("FollowArtistMatrix.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, matrizSeguirCantantes);
            stream.Close();

        }

        public void dejardeSeguirCantante(int userID, int singerID)
        {
            //Cambio var de estado en matriz. 
            matrizSeguirCantantes[userID][singerID] = false;

            //Serializo y guardo. 

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("FollowArtistMatrix.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, matrizSeguirCantantes);
            stream.Close();


        }

    }
}
