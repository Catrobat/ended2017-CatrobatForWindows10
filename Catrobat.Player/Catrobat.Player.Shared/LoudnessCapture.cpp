#include "pch.h"
#include "LoudnessCapture.h"

#include "DeviceInformation.h"
#include "PlayerException.h"

#include <string.h>
#include <sstream>
#include <math.h>

using namespace std;

using namespace Windows::System;
using namespace Windows::System::Threading;
using namespace Windows::Foundation;
using namespace Platform;

LoudnessCapture::LoudnessCapture() 
{
	m_isRecording = false;
	m_loudness = 0.0;
	m_timeLastQuery = clock();
}

double LoudnessCapture::GetLoudness()
{
	return m_loudness;
}

bool LoudnessCapture::StartCapture()
{
	if (DeviceInformation::IsRunningOnDevice())
	{
		if (!m_isRecording)
		{
				return true;
		}
	}
	else
	{
		return false;
		//throw new PlayerException("init WASAPI failed, Microphone is not supported");
	}
			
	return false;
}

bool LoudnessCapture::StopCapture()
{
	if (m_isRecording)
	{
			return true;
	}

	return false;
}

void LoudnessCapture::StartPeriodicCalculationLoudness()
{
}

void LoudnessCapture::UpdateLoudness(int value)
{
}

double LoudnessCapture::GetTimeSinceLastQuery()
{
	return (double)(clock() - this->m_timeLastQuery) / CLOCKS_PER_SEC;
}

