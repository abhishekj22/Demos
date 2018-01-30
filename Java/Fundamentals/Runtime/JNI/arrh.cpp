#include "ArrayHelper.h"

JNIEXPORT jdouble JNICALL Java_ArrayHelper_sumOf(JNIEnv* env, jclass, jdoubleArray arr)
{
	jint n = env->GetArrayLength(arr);
	jdouble* values = env->GetDoubleArrayElements(arr, NULL);
	jdouble sum = 0;

	for(jint i = 0; i < n; ++i)
		sum += values[i];

	env->ReleaseDoubleArrayElements(arr, values, JNI_ABORT);

	return sum;
}

JNIEXPORT void JNICALL Java_ArrayHelper_squareAll(JNIEnv* env, jclass, jdoubleArray arr)
{
	jint n = env->GetArrayLength(arr);
	jdouble* values = new jdouble[n];
	env->GetDoubleArrayRegion(arr, 0, n, values);

	for(jint i = 0; i < n; ++i)
		values[i] *= values[i];

	env->SetDoubleArrayRegion(arr, 0, n, values);
	delete[] values;
}
