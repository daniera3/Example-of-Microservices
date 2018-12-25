package models;

import java.util.ArrayList;

public class movieClass {
	private ArrayList<Star> stars=new ArrayList<Star>();
	private ArrayList<Director> diractors=new ArrayList<Director>();
	private ArrayList<Ganers> Ganer = new ArrayList<Ganers>();
	private Imge Img ;
	private String Outline ;
	private int Idmovie ;
	private String Title ;
	private int Idimg ;
	private String Time ;
	private int Rating ;
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

	

	public String Certificate ;

	public movieClass (int idmovie, String t, int idimg, String time, int rating, String Certificate, String outline)
    {
        this.Idmovie = idmovie;
        this.Title = t;
        this.Idimg = idimg;
        this.Time = time;
        this.Rating = rating;
        this.Outline = outline;
        this.Certificate = Certificate;

    }

	public void addStars(Star stars) {
		this.stars.add(stars);
	}
	
	
	public void addDiractors(Director dir) {
		this.diractors.add(dir);
	}

	public ArrayList<Star> getStars() {
		return stars;
	}
	public ArrayList<Director> getDiracors(){
		return diractors;
	}

	public ArrayList<Ganers> getGaner() {
		return Ganer;
	}

	public void addGaner(Ganers ganer) {
		this.Ganer.add(ganer);
	}





}
