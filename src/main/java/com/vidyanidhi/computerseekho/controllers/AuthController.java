//package com.vidyanidhi.computerseekho.controllers;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.security.authentication.AuthenticationManager;
//import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
//import org.springframework.security.core.userdetails.UserDetails;
//import org.springframework.security.core.userdetails.UserDetailsService;
//import org.springframework.web.bind.annotation.PostMapping;
//import org.springframework.web.bind.annotation.RequestBody;
//import org.springframework.web.bind.annotation.RestController;
//
//import com.vidyanidhi.computerseekho.config.JwtRequest;
//import com.vidyanidhi.computerseekho.config.JwtUtil;
//
//@RestController
//public class AuthController {
//
//    @Autowired
//    private AuthenticationManager authenticationManager;
//
//    @Autowired
//    private JwtUtil jwtUtil;
//
//    @Autowired
//    private UserDetailsService userDetailsService;
//
//    @PostMapping("/authenticate")
//    public String createAuthenticationToken(@RequestBody JwtRequest authRequest) throws Exception {
//        try {
//            authenticationManager.authenticate(
//                    new UsernamePasswordAuthenticationToken(authRequest.getUsername(), authRequest.getPassword())
//            );
//        } catch (Exception e) {
//            throw new RuntimeException("Invalid username/password");
//        }
//
//        final UserDetails userDetails = userDetailsService.loadUserByUsername(authRequest.getUsername());
//        final String jwt = jwtUtil.generateToken(userDetails.getUsername());
//
//        return jwt;
//    }
//
//}