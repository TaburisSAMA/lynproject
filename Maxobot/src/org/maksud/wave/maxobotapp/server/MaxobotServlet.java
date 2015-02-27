package org.maksud.wave.maxobotapp.server;

import com.google.wave.api.AbstractRobotServlet;
import com.google.wave.api.Blip;
import com.google.wave.api.Event;
import com.google.wave.api.EventType;
import com.google.wave.api.RobotMessageBundle;
import com.google.wave.api.TextView;
import com.google.wave.api.Wavelet;



public class MaxobotServlet extends AbstractRobotServlet {

	private static final long serialVersionUID = 1L;
	
	

	@Override
	public void processEvents(RobotMessageBundle bundle) {
		Wavelet wavelet = bundle.getWavelet();

		if (bundle.wasSelfAdded()) {
			Blip blip = wavelet.appendBlip();
			TextView textView = blip.getDocument();
			textView.append("I'm alive!");
		}

		for (Event e : bundle.getEvents()) {
			if (e.getType() == EventType.WAVELET_PARTICIPANTS_CHANGED) {
				Blip blip = wavelet.appendBlip();
				TextView textView = blip.getDocument();
				textView.append("Hi, everybody!");
			}
			
			System.err.print("New Evemt Occured!");
			System.err.print(e.getType().toString());

		}

	}

}
