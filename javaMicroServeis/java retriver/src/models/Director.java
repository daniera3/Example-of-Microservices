package models;
    public class Director
    {
        private int idmovie ;
        private String NameDirector ;
       
        public Director(String url, int id)
        {
            idmovie = id;
            NameDirector = url;
        }
		public int getIdmovie() {
			return idmovie;
		}
		public String getNameDirector() {
			return NameDirector;
		}
    }