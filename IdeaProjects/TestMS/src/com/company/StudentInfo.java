package com.company;

public class StudentInfo {
    private int stu_id;

    public int getStu_id() {
        return stu_id;
    }

    public void setStu_id(int stu_id) {
        this.stu_id = stu_id;
    }

    public String getStu_name() {
        return stu_name;
    }

    public void setStu_name(String stu_name) {
        this.stu_name = stu_name;
    }

    public int getStu_age() {
        return stu_age;
    }

    public void setStu_age(int stu_age) {
        this.stu_age = stu_age;
    }

    public String getStu_phone() {
        return stu_phone;
    }

    public void setStu_phone(String stu_phone) {
        this.stu_phone = stu_phone;
    }

    public double getStu_score() {
        return stu_score;
    }

    public void setStu_score(double stu_score) {
        this.stu_score = stu_score;
    }

    private String stu_name;
    private int stu_age;
    private String stu_phone;
    private double stu_score;
}
