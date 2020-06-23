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
    class MatrizSeguidores
    {
        public List<List<bool>> matrizSeguidores;

        public MatrizSeguidores()
        {
            //Al inicializar la matriz, checkeo si esta el archivo "FollowMatrixU.bin".

            //Si esta, simplemente la cargo. 
            if (File.Exists("FollowMatrixU.bin") == true)
            {
                IFormatter formatter2 = new BinaryFormatter();
                Stream stream2 = new FileStream("FollowMatrixU.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                try
                {
                    List<List<bool>> matrizCargada = (List<List<bool>>)formatter2.Deserialize(stream2);

                    this.matrizSeguidores = matrizCargada;

                    stream2.Close();
                  
                }

                //Si esta vacia, guardo. 

                catch (SerializationException)
                {
                    List < List<bool> > matrizCargada = new List<List<bool>>();
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
                    this.matrizSeguidores = matrizCargada;
                    formatter2.Serialize(stream2, matrizCargada);
                    stream2.Close();
                    throw;
                }
            }


            //Si no esta archivo, creo nueva matriz y guardo en archivo. 
            if (File.Exists("FollowMatrixU.bin") == false)
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



                this.matrizSeguidores = matrizCargada;


                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("FollowMatrixU.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                formatter.Serialize(stream, matrizCargada);
                stream.Close();
            }



        }

        public void seguirUsuario(int userID, int followedID)
        {
            //Cambio var de estado en matriz.
            matrizSeguidores[userID][followedID-1] = true;

            //Serializo y guardo. 

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("FollowMatrixU.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, matrizSeguidores);
            stream.Close();

        }

        public void dejardeSeguirUsuario(int userID, int followedID)
        {
            //Cambio var de estado en matriz. 
            matrizSeguidores[userID][followedID-1] = false;

            //Serializo y guardo. 

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("FollowMatrixU.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, matrizSeguidores);
            stream.Close();


        }

    }
}
