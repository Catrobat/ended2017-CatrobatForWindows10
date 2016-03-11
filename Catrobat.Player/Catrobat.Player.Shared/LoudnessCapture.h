#pragma once

#include <ppltasks.h>
#include <time.h>

ref class LoudnessCapture sealed
{
public:

	LoudnessCapture();

	double GetLoudness();
	bool StartCapture();
	bool StopCapture();

	void UpdateLoudness(int value);
	
	double GetTimeSinceLastQuery();

private:

	double m_loudness;
	bool m_isRecording;
	clock_t m_timeLastQuery;
	
	void StartPeriodicCalculationLoudness();
	Windows::System::Threading::ThreadPoolTimer^ m_timer;
};

