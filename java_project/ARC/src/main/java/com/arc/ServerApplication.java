package com.arc;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.sql2o.Sql2o;

@SpringBootApplication
//@ComponentScan({"org.sql2o","com.arc"})

public class ServerApplication {

	public static void main(String[] args) {
//		JavaConfigApplicationContext context =
//			    new JavaConfigApplicationContext(ServerApplication.class);
//		org.sql2o.Sql2o service = context.getBean(Sql2o.class);
		SpringApplication.run(ServerApplication.class, args);
	}
}
