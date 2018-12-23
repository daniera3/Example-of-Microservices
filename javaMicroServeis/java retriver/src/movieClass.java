import java.util.ArrayList;


public class movieClass {
	
	public Imge Img ;
    public String Outline ;
    public int Idmovie ;
    public String Title ;
    public int Idimg ;
    public String Time ;
    public int Rating ;
    public Imge getImg() {
		return Img;
	}

	public void setImg(Imge img) {
		Img = img;
	}

	public String getOutline() {
		return Outline;
	}

	public void setOutline(String outline) {
		Outline = outline;
	}

	public int getIdmovie() {
		return Idmovie;
	}

	public void setIdmovie(int idmovie) {
		Idmovie = idmovie;
	}

	public String getTitle() {
		return Title;
	}

	public void setTitle(String title) {
		Title = title;
	}

	public int getIdimg() {
		return Idimg;
	}

	public void setIdimg(int idimg) {
		Idimg = idimg;
	}

	public String getTime() {
		return Time;
	}

	public void setTime(String time) {
		Time = time;
	}

	public int getRating() {
		return Rating;
	}

	public void setRating(int rating) {
		Rating = rating;
	}

	public String getCertificate() {
		return Certificate;
	}

	public void setCertificate(String certificate) {
		Certificate = certificate;
	}

	public ArrayList<Star> getStr() {
		return Str;
	}

	public void setStr(ArrayList<Star> str) {
		Str = str;
	}

	public ArrayList<Ganers> getGaner() {
		return Ganer;
	}

	public void setGaner(ArrayList<Ganers> ganer) {
		Ganer = ganer;
	}

	public ArrayList<Director> getDir() {
		return Dir;
	}

	public void setDir(ArrayList<Director> dir) {
		Dir = dir;
	}

	public String Certificate ;
    public ArrayList<Star> Str ;
    public ArrayList<Ganers> Ganer ;
    public ArrayList<Director> Dir ;
	public movieClass (int idmovie, String t, int idimg, String time, int rating, String Certificate, String outline)
    {
        this.Idmovie = idmovie;
        this.Title = t;
        this.Idimg = idimg;
        this.Time = time;
        this.Rating = rating;
        this.Outline = outline;
        this.Certificate = Certificate;
        this.Str = new ArrayList<Star>();
        this.Dir = new ArrayList<Director>();
        this.Ganer = new ArrayList<Ganers>();
    }
    public class Star
    {
        public int Idmovie ;
        public String Namestar ;
        public Star(String url, int id)
        {
            Idmovie = id;
            Namestar = url;
        }
    }
    public class Ganers
    {
        public int Idmovie ;
        public String NameGaner ;

        public Ganers(String url, int id)
        {
            Idmovie = id;
            NameGaner = url;
        }
    }
    
    public class Director
    {
        public int idmovie ;
        public String NameDirector ;
       
        public Director(String url, int id)
        {
            idmovie = id;
            NameDirector = url;
        }
    }

    public class Imge
    {
    public int idimg;
    public String img ;
    public String title ;
    public String alt ;
    public String width ;
    public String height ;
    
    public Imge(int id, String url, String titl, String alt, String width, String height)
    {
        idimg = id;
        img = url;
        title = titl;
        this.alt = alt;
        this.width = width;
        this.height = height;
    }
}
}
