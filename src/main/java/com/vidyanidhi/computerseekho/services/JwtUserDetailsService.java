//package com.vidyanidhi.computerseekho.services;
//
//import java.util.ArrayList;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.security.core.userdetails.UserDetails;
//import org.springframework.security.core.userdetails.UserDetailsService;
//import org.springframework.security.core.userdetails.UsernameNotFoundException;
//import org.springframework.stereotype.Service;
//
//import com.vidyanidhi.computerseekho.entities.Staff;
//import com.vidyanidhi.computerseekho.repositories.StaffRepository;
//
//@Service
//public class JwtUserDetailsService implements UserDetailsService {
//
//    @Autowired
//    private StaffRepository staffRepository;
//
//    @Override
//    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
//        Staff staff = staffRepository.findByUsername(username);
//        if (staff == null) {
//            throw new UsernameNotFoundException("User not found");
//        }
//        return new org.springframework.security.core.userdetails.User(staff.getStaff_username(), staff.getStaff_password(), new ArrayList<>());
//    }
//}