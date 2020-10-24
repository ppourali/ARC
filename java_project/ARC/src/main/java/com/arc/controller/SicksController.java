package com.arc.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.arc.model.Sick;
import com.arc.model.User;
import com.arc.repository.imp.SickRepositoryImpl;

@RestController
@RequestMapping("/sicks")
public class SicksController {

	/** The JPA repository */
	// @Autowired
//	private SickRepositoryImpl sicksJpaRespository;

	/**
	 * Used to fetch all the users from DB
	 * 
	 * @return list of {@link User}
	 */
	@GetMapping(value = "/all")
	public List<Sick> findAll() {
		System.out.println("hi");
		return null;// sicksJpaRespository.findAll();
	}
}
