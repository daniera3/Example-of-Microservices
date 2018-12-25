package models;
    public class Ganers
    {
        private int Idmovie ;
        private String NameGaner ;
        public Ganers(String url, int id)
        {
            Idmovie = id;
            NameGaner = url;
        }
		public int getIdmovie() {
			return Idmovie;
		}
		public String getNameGaner() {
			return NameGaner;
		}
    }
    