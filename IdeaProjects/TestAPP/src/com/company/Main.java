package com.company;

import java.util.Random;

public class Main {
    public static void main(String[] args) {
        int temp,g=0;
        double p,sum = 0;
        for (int i = 0; i < 100; i++) {
            g=0;
            for (int j = 0; j < 1000000; j++) {
                Random r = new Random();
                temp = r.nextInt(100000);
                if (temp>=99999){
                    g++;
                }
            }
            p=(double)g/1000000*10000;
            sum+=p;
//            System.out.printf("中奖概率为%.2f‱",((double)g/1000000)*10000);
            System.out.printf("中奖概率为%.2f‱\n",p);
        }
        System.out.printf("平均概率为%.4f‱",(sum/100));
    }
}
