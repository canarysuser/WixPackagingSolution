// Calculator.cpp : Implementation of CCalculator

#include "pch.h"
#include "Calculator.h"

STDMETHODIMP CCalculator::AddNumbers(long a, long b, long* result) {
	*result = a + b;
	return S_OK;
}
// CCalculator

