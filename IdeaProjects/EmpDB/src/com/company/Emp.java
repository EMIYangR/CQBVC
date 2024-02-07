package com.company;

import java.util.Date;

public class Emp {
    private int empId;

    public int getEmpId() {
        return empId;
    }

    public void setEmpId(int empId) {
        this.empId = empId;
    }

    public String getEmpName() {
        return empName;
    }

    public void setEmpName(String empName) {
        this.empName = empName;
    }

    public String getEnpjob() {
        return enpjob;
    }

    public void setEnpjob(String enpjob) {
        this.enpjob = enpjob;
    }

    public int getEmpsal() {
        return empsal;
    }

    public void setEmpsal(int empsal) {
        this.empsal = empsal;
    }

    public Date getEmpdate() {
        return empDate;
    }

    public void setEmpdate(Date empdate) {
        this.empDate = empdate;
    }

    private String empName;
    private String enpjob;
    private int empsal;
    private Date empDate;
}
