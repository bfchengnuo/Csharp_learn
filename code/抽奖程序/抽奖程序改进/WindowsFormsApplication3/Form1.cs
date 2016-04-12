﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        //定义二个集合来存放ID和姓名，提供映射关系
        List<string> idList = new List<string>();
        List<string> nameList = new List<string>();
        //存储随机数
        int i = 0;
        //配置文件路径
        string filepath = @".\src\";
        //定义标志位控制按钮开关
        bool flag = true;

        // addGroup addgroup = new addGroup();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //读取文件，将文件信息分别写入两个list集合
            new addList().Show(idList, nameList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                bunStart();
            }
            else
            {
                btnStop();
            }
        }
        //重置按钮
        private void button2_Click(object sender, EventArgs e)
        {
            btnClean();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerShow();
        }



        //时钟事件
        private void TimerShow()
        {
            Random random = new Random();
            i = random.Next(0, idList.Count);
            pictureBox1.Image = System.Drawing.Bitmap.FromFile(filepath + idList[i] + ".jpg");
            //文件名和姓名在label标签显示
            label1.Text = nameList[i];
            label2.Text = idList[i];

        }
        //按钮1停止抽取
        private void btnStop()
        {
            timer1.Enabled = false;
            //将抽取到的同学添加到容器，并删除此同学
            new addGroup().addPic(idList, nameList, i, panel1, filepath);
            flag = true;
            button1.Text = "开始";
        }
        //按钮1开始抽取
        private void bunStart()
        {
            if (idList.Count != 0)
            {
                timer1.Enabled = true;
                timer1.Interval = 100;
                flag = false;
                button1.Text = "停止";
            }
            else
            {
                MessageBox.Show("已经全部取完！");
            }
        }
        //按钮2清除方法
        private void btnClean()
        {
            idList.Clear();
            nameList.Clear();
            panel1.Controls.Clear();
            pictureBox1.Image = null;
            label1.Text = "";
            label2.Text = "";
            new addList().Show(idList, nameList);
            addGroup.s = 0;
        }

    }
}
