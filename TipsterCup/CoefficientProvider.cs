using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    class CoefficientProvider
    {
        private static double[] diff = {-0.5, 0, 0.5};
        private static double[,] coeff = new double[21, 7];
        private static int[] lowerBound = {500, 450, 400, 350, 300, 250, 200, 150, 100, 50, 0, 
                        -50, -100, -150, -200, -250, -300, -350, -400, -450, -200000000};
        static Random random;

        public CoefficientProvider()
        {
            #region Coefficients Initialization
            coeff[0, 0] = 1.25;
            coeff[0, 1] = 5.75;
            coeff[0, 2] = 10.5;
            coeff[0, 3] = 2.2;
            coeff[0, 4] = 1.6;
            coeff[0, 5] = 2.6;
            coeff[0, 6] = 8.5;

            coeff[1, 0] = 1.4;
            coeff[1, 1] = 4.4;
            coeff[1, 2] = 6.2;
            coeff[1, 3] = 2.5;
            coeff[1, 4] = 1.4;
            coeff[1, 5] = 2;
            coeff[1, 6] = 8.25;

            coeff[2, 0] = 1.55;
            coeff[2, 1] = 3.95;
            coeff[2, 2] = 6.35;
            coeff[2, 3] = 1.8;
            coeff[2, 4] = 2.0;
            coeff[2, 5] = 3.5;
            coeff[2, 6] = 12.5;

            coeff[3, 0] = 1.7;
            coeff[3, 1] = 3.7;
            coeff[3, 2] = 5.1;
            coeff[3, 3] = 1.7;
            coeff[3, 4] = 2.1;
            coeff[3, 5] = 3.8;
            coeff[3, 6] = 13.5;

            coeff[4, 0] = 1.85;
            coeff[4, 1] = 3.3;
            coeff[4, 2] = 3.75;
            coeff[4, 3] = 2.0;
            coeff[4, 4] = 1.7;
            coeff[4, 5] = 2.45;
            coeff[4, 6] = 14.5;

            coeff[5, 0] = 2.0;
            coeff[5, 1] = 3.2;
            coeff[5, 2] = 3.35;
            coeff[5, 3] = 1.9;
            coeff[5, 4] = 1.7;
            coeff[5, 5] = 2.5;
            coeff[5, 6] = 16.0;

            coeff[6, 0] = 2.15;
            coeff[6, 1] = 3.15;
            coeff[6, 2] = 3.2;
            coeff[6, 3] = 1.75;
            coeff[6, 4] = 1.8;
            coeff[6, 5] = 2.5;
            coeff[6, 6] = 16.5;

            coeff[7, 0] = 2.3;
            coeff[7, 1] = 3.0;
            coeff[7, 2] = 3.1;
            coeff[7, 3] = 1.7;
            coeff[7, 4] = 1.75;
            coeff[7, 5] = 2.6;
            coeff[7, 6] = 18;

            coeff[8, 0] = 2.45;
            coeff[8, 1] = 2.95;
            coeff[8, 2] = 2.65;
            coeff[8, 3] = 1.75;
            coeff[8, 4] = 2.05;
            coeff[8, 5] = 3.6;
            coeff[8, 6] = 18.5;

            coeff[9, 0] = 2.6;
            coeff[9, 1] = 2.9;
            coeff[9, 2] = 2.7;
            coeff[9, 3] = 1.8;
            coeff[9, 4] = 2.0;
            coeff[9, 5] = 3.1;
            coeff[9, 6] = 17.0;

            coeff[10, 0] = 2.75;
            coeff[10, 1] = 3.0;
            coeff[10, 2] = 2.6;
            coeff[10, 3] = 1.6;
            coeff[10, 4] = 1.8;
            coeff[10, 5] = 2.95;
            coeff[10, 6] = 16;

            coeff[11, 0] = 2.9;
            coeff[11, 1] = 3.2;
            coeff[11, 2] = 2.15;
            coeff[11, 3] = 1.7;
            coeff[11, 4] = 1.9;
            coeff[11, 5] = 2.85;
            coeff[11, 6] = 19.5;

            coeff[12, 0] = 3.05;
            coeff[12, 1] = 3.8;
            coeff[12, 2] = 1.95;
            coeff[12, 3] = 1.9;
            coeff[12, 4] = 1.8;
            coeff[12, 5] = 2.65;
            coeff[12, 6] = 15;

            coeff[13, 0] = 3.2;
            coeff[13, 1] = 3.85;
            coeff[13, 2] = 2.05;
            coeff[13, 3] = 1.85;
            coeff[13, 4] = 1.7;
            coeff[13, 5] = 2.8;
            coeff[13, 6] = 14.5;

            coeff[14, 0] = 3.35;
            coeff[14, 1] = 4.25;
            coeff[14, 2] = 2.15;
            coeff[14, 3] = 1.95;
            coeff[14, 4] = 1.65;
            coeff[14, 5] = 2.45;
            coeff[14, 6] = 12.5;

            coeff[15, 0] = 3.5;
            coeff[15, 1] = 5.85;
            coeff[15, 2] = 1.85;
            coeff[15, 3] = 2.15;
            coeff[15, 4] = 1.55;
            coeff[15, 5] = 2.15;
            coeff[15, 6] = 10.05;

            coeff[16, 0] = 3.75;
            coeff[16, 1] = 3.45;
            coeff[16, 2] = 1.8;
            coeff[16, 3] = 1.75;
            coeff[16, 4] = 1.65;
            coeff[16, 5] = 2.65;
            coeff[16, 6] = 9.25;

            coeff[17, 0] = 4.5;
            coeff[17, 1] = 3.8;
            coeff[17, 2] = 1.6;
            coeff[17, 3] = 1.7;
            coeff[17, 4] = 1.65;
            coeff[17, 5] = 2.45;
            coeff[17, 6] = 8.5;

            coeff[18, 0] = 6.8;
            coeff[18, 1] = 3.95;
            coeff[18, 2] = 1.5;
            coeff[18, 3] = 1.75;
            coeff[18, 4] = 1.6;
            coeff[18, 5] = 2.25;
            coeff[18, 6] = 9.0;

            coeff[19, 0] = 8.5;
            coeff[19, 1] = 4.1;
            coeff[19, 2] = 1.4;
            coeff[19, 3] = 1.95;
            coeff[19, 4] = 1.55;
            coeff[19, 5] = 2.2;
            coeff[19, 6] = 8.75;

            coeff[20, 0] = 10.5;
            coeff[20, 1] = 5.5;
            coeff[20, 2] = 1.25;
            coeff[20, 3] = 2.2;
            coeff[20, 4] = 1.5;
            coeff[20, 5] = 2.05;
            coeff[20, 6] = 7.5;

            #endregion
        }

        public void fillShowCoeff(int idMatch)
        {
            int id = firstCoeffId(idMatch);
            for (int i = 0; i < 7; i++)
            {
                using (OracleConnection conn = new OracleConnection(FormLogin.connString))
                {
                    conn.Open();
                    String query = "INSERT INTO SHOWCOEFF(idCoefficient,value,idMatch) VALUES(" + (i + 1) + 
                        ", " + getCoefficient(idMatch, (i + 1)) + ", " + idMatch + ")";
                    OracleCommand command = new OracleCommand(query, conn);
                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();

                }
                id++;
            }
            
        }

        public static void fillShowCoeffRound(int roundId) 
        {
            using (OracleConnection connection = new OracleConnection(FormLogin.connString))
            {
                connection.Open();
                OracleCommand command;
                OracleDataReader reader;
                String query;

                
                //site natprevari od dadena runda
                query = "SELECT idMatch FROM Match WHERE idRound = " + roundId;
                command = new OracleCommand(query, connection);
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idMatch = Convert.ToInt32(reader[0]);

                    int idNext = firstCoeffId(idMatch) ;
                    for (int i = 0; i < 7; i++)
                    {
                        try
                        {
                            query = "INSERT INTO SHOWCOEFF(idCoefficient,value,idMatch) VALUES(" + (i + 1) +
                       ", " + getCoefficient(idMatch, (i + 1)) + ", " + idMatch + ")";
                            command = new OracleCommand(query, connection);
                            command.CommandType = CommandType.Text;

                            command.ExecuteNonQuery();

                            idNext++;
                        }
                        catch (OracleException ex) { }
                    }

                }

                
            }
        }

        public static double getCoefficient(int idMatch, int type)//dava vrednost na koef. za daden natprevar
        {
            Match m = FormLogin.docMain.getMatchById(idMatch);
            random = new Random();
            type--;
            int ratingDiff = (int)(m.HomeTeam.Rating - m.GuestTeam.Rating);
            for (int i = 0; i < coeff.Length; i++)
            {
                if (ratingDiff > lowerBound[i])
                {
                     return coeff[i, type] + diff[random.Next(3)];

                }
            }
            return 100;
        }

        public double[] getCoefficientsForMatch(int idMatch)//dobivanje na site koefficienti za daden natprevar
        {              //koef. so id = i od bazata ovde ima id = i - 1 
            Match m = FormLogin.docMain.getMatchById(idMatch);
            random = new Random();
            double[] ret = new double[7];
            int ratingDiff = (int)(m.HomeTeam.Rating - m.GuestTeam.Rating);
            for (int i = 0; i < lowerBound.Length; i++)
            {
                if (ratingDiff > lowerBound[i])
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (Math.Abs(coeff[i, j] - 0.0) < 0.000001)
                        {
                            throw new Exception() { };
                        }
                        ret[j] = coeff[i, j] + diff[random.Next(3)];
                    }
                    return ret;
                }
                
                    
            }
            return null;
        }

        private static int firstCoeffId(int idMatch) {
            return (idMatch - 1) * 7 + 1;
        }

    }
}
