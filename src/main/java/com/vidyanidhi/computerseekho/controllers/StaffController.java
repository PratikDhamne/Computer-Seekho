package com.vidyanidhi.computerseekho.controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import com.vidyanidhi.computerseekho.entities.Enquiry;
import com.vidyanidhi.computerseekho.entities.Staff;
import com.vidyanidhi.computerseekho.services.StaffManager;

@RestController 
public class StaffController {
	@Autowired
	StaffManager manager;
	@GetMapping(value="api/getEnqbystaff/{id}")
	   public List<Enquiry> getAllEnqForStaff(@PathVariable int id) {
		return manager.getAllEnquiriesForStaff(id);
	}	
	@GetMapping(value = "api/staff")
	public List <Staff > showStaff() {
		return manager.getStaff();
	}
	
	@GetMapping(value = "api/staff/{sid}")
	public Optional <Staff> getStaff(@PathVariable int sid) {

		Optional<Staff> s = manager.getStaff(sid);
		
		return s;
	}
	
	@GetMapping(value = "api/stafflog/{uname}")
	public ResponseEntity<Staff> slogin(@PathVariable String uname) {
	    Staff staff = manager.stafflogin(uname);
	    if (staff != null) {
	        return ResponseEntity.ok(staff);
	    } else {
	        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(null);
	    }
	}

	
	@PostMapping(value = "api/staff")
	public void addStaff(@RequestBody Staff s) {
		manager.addStaff(s);
	}
	
	@PutMapping(value="api/staff/{sid}")
	public void updateStaff(@RequestBody Staff s, @PathVariable int sid) {
		manager.updateStaffData(s, sid);
	}
	
	@DeleteMapping(value="api/staff/{sid}")
	public void delelteStaff(@PathVariable int sid) {
		manager.delete(sid);
	}
}
