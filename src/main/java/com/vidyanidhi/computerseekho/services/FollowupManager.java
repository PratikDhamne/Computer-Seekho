package com.vidyanidhi.computerseekho.services;

import java.util.*;

import com.vidyanidhi.computerseekho.entities.Enquiry;
import com.vidyanidhi.computerseekho.entities.Followup;


public interface FollowupManager {
	void addFollowup(Followup followup);
	public List<Enquiry> GetAllFollowUp();
	public List<Enquiry> GetFollowUpByStaffId(int staffid);

}
