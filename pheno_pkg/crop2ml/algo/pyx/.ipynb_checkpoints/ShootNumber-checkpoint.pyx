
cdef int emergedLeaves, shoots, i
cdef intlist lNumberArray_rate
emergedLeaves = max(1, ceil(leafNumber - 1.0))
shoots = fibonacci(emergedLeaves)
canopyShootNumber = min(shoots * sowingDensity, targetFertileShoot)
averageShootNumberPerPlant = canopyShootNumber / sowingDensity
if (canopyShootNumber != canopyShootNumber_t1):
    tilleringProfile = integr(tilleringProfile_t1,canopyShootNumber - canopyShootNumber_t1)
tillerNumber = len(tilleringProfile)
for i in range(len(leafTillerNumberArray_t1),ceil(leafNumber),1):
    lNumberArray_rate.append(tillerNumber)
leafTillerNumberArray = integr(leafTillerNumberArray_t1, lNumberArray_rate)