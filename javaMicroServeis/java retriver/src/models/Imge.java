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