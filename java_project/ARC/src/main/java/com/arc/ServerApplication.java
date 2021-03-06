package com.arc;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootApplication
@ComponentScan("org.sql2o")
@EnableJpaRepositories("com.arc.repository")
@EnableAutoConfiguration
public class ServerApplication {

	public static void main(String[] args) {
//		JavaConfigApplicationContext context =
//			    new JavaConfigApplicationContext(ServerApplication.class);
//		org.sql2o.Sql2o service = context.getBean(Sql2o.class);
		SpringApplication.run(ServerApplication.class, args);
	}
}
