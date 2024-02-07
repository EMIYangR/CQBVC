package com.company;

public class MyCircle extends Shape{
    private double radius;//圆的半径
    public static final double PI=3.14;

    public MyCircle(){}

    public MyCircle(double r){
        this.radius=r;
    }

    public void setRadius(double radius){
        this.radius=radius;
    }

    public double getRadius(){
        return radius;
    }

    public double getArea(){
        return PI*this.radius*this.radius;
    }

    public double getPerimeter(){
        return 2*PI*this.radius;
    }

    public String toString(){
        System.out.println("radius="+this.radius+",perimeter="+this.getPerimeter()+",area="+this.getArea());
        return null;
    }
}
