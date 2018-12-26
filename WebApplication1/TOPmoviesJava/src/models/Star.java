package models;

    public class Star
    {
        private int Idmovie ;
        private String Namestar ;
        public int getIdmovie() {
			return Idmovie;
		}
		public String getNamestar() {
			return Namestar;
		}
		public Star(String url, int id)
        {
            Idmovie = id;
            Namestar = url;
        }
    }