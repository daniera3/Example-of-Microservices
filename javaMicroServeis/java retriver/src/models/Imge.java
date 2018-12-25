package models;
    public class Imge
    {
    private int idimg;
    private String img ;
    private String title ;
    private String alt ;
    private String width ;
    private String height ;
    
    public int getIdimg() {
		return idimg;
	}

	public String getImg() {
		return img;
	}
	public String getTitle() {
		return title;
	}
	public String getAlt() {
		return alt;
	}

	public String getWidth() {
		return width;
	}

	public String getHeight() {
		return height;
	}

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