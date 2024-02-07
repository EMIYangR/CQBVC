package com.company;

import java.util.Scanner;

public class Test {
    public static void main(String[] args) {
        Scanner input=new Scanner(System.in);
        MyCircle mc = new MyCircle();

        System.out.println("请输入圆的半径：");
        double r=input.nextDouble();

        mc.setRadius(r);
        mc.toString();
    }
}
