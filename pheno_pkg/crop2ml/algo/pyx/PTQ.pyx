cdef floatlist TTList
cdef floatlist PARList
cdef int i, count
cdef float SumTT, parInt = 0.0, TTShoot;
for i in range(0,len(listTTShootWindowForPTQ)):
    TTList.append(listTTShootWindowForPTQ[i])
    PARList.append(listPARTTWindowForPTQ[i])
TTList.append(deltaTT)
PARList.append(pAR)
SumTT= sum(TTList)
count=0
while (SumTT > tTWindowForPTQ):
    SumTT -= TTList[count]
    count = count +1
listTTShootWindowForPTQ=[]
listPARTTWindowForPTQ=[]
for i in range(count, len(TTList)):
    listTTShootWindowForPTQ.append(TTList[i])
    listPARTTWindowForPTQ.append(PARList[i])
for i in range(0, len(listTTShootWindowForPTQ)): parInt = parInt + listPARTTWindowForPTQ[i] * (1 - exp(-kl * listGAITTWindowForPTQ[i]));
TTShoot = sum(listTTShootWindowForPTQ)
ptq = parInt / TTShoot
