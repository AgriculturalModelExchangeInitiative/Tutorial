
# This file has been generated at Mon Aug 30 19:03:54 2021

from openalea.core import *


__name__ = 'Snow'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'OpenAlea Consortium'
__institutes__ = 'INRA/CIRAD'
__description__ = 'CropML Model library.'
__url__ = 'http://pycropml.rtfd.org'
__icon__ = ''


__all__ = ['Melting_model_melting', 'Refreezing_model_refreezing', 'Snowaccumulation_model_snowaccumulation', 'Snowdensity_model_snowdensity', 'Snowdepth_model_snowdepth', 'Snowdepthtrans_model_snowdepthtrans', 'Snowdry_model_snowdry', 'Snowmelt_model_snowmelt', 'Snowwet_model_snowwet', 'Tavg_model_tavg', 'Tempmax_model_tempmax', 'Tempmin_model_tempmin', 'Preciprec_model_preciprec']



Melting_model_melting = Factory(name='Melting',
                authors='OpenAlea Consortium (wralea authors)',
                description='It simulates snow in the process of melting',
                category='',
                nodemodule='Melting',
                nodeclass='model_melting',
                inputs=[{'name': 'jul', 'interface': IInt(min=0, max=366, step=1), 'value': 0}, {'name': 'Tmf', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.5}, {'name': 'DKmax', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'Kmin', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'tavg', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'M', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Refreezing_model_refreezing = Factory(name='Refreezing',
                authors='OpenAlea Consortium (wralea authors)',
                description='It simulates the depth of snow cover and recalculate weather data',
                category='',
                nodemodule='Refreezing',
                nodeclass='model_refreezing',
                inputs=[{'name': 'tavg', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'Tmf', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'SWrf', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'Mrf', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Snowaccumulation_model_snowaccumulation = Factory(name='SnowAccumulation',
                authors='OpenAlea Consortium (wralea authors)',
                description='It simulates the depth of snow cover and recalculate weather data',
                category='',
                nodemodule='Snowaccumulation',
                nodeclass='model_snowaccumulation',
                inputs=[{'name': 'tsmax', 'interface': IFloat(min=0, max=1000, step=1.000000), 'value': 0.0}, {'name': 'tmax', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'trmax', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'precip', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'Snowaccu', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Snowdensity_model_snowdensity = Factory(name='SnowDensity',
                authors='OpenAlea Consortium (wralea authors)',
                description='density of snow cover',
                category='',
                nodemodule='Snowdensity',
                nodeclass='model_snowdensity',
                inputs=[{'name': 'ps_t1', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'Sdepth_t1', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'Sdry_t1', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'Swet_t1', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'ps', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Snowdepth_model_snowdepth = Factory(name='SnowDepth',
                authors='OpenAlea Consortium (wralea authors)',
                description='snow cover depth Calculation',
                category='',
                nodemodule='Snowdepth',
                nodeclass='model_snowdepth',
                inputs=[{'name': 'Snowmelt', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'Sdepth_t1', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'Snowaccu', 'interface': IFloat, 'value': 0.0}, {'name': 'E', 'interface': IFloat, 'value': 0.0}, {'name': 'rho', 'interface': IFloat, 'value': 100}],
                outputs=[{'name': 'Sdepth', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Snowdepthtrans_model_snowdepthtrans = Factory(name='SnowDepthTrans',
                authors='OpenAlea Consortium (wralea authors)',
                description='snow cover depth in cm',
                category='',
                nodemodule='Snowdepthtrans',
                nodeclass='model_snowdepthtrans',
                inputs=[{'name': 'Sdepth', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'Pns', 'interface': IFloat, 'value': 100.0}],
                outputs=[{'name': 'Sdepth_cm', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Snowdry_model_snowdry = Factory(name='SnowDry',
                authors='OpenAlea Consortium (wralea authors)',
                description='water in solid state in the snow cover',
                category='',
                nodemodule='Snowdry',
                nodeclass='model_snowdry',
                inputs=[{'name': 'Sdry_t1', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'Snowaccu', 'interface': IFloat, 'value': 0.0}, {'name': 'Mrf', 'interface': IFloat, 'value': 0.0}, {'name': 'M', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'Sdry', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Snowmelt_model_snowmelt = Factory(name='SnowMelt',
                authors='OpenAlea Consortium (wralea authors)',
                description='Snow melt',
                category='',
                nodemodule='Snowmelt',
                nodeclass='model_snowmelt',
                inputs=[{'name': 'ps', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'M', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'Snowmelt', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Snowwet_model_snowwet = Factory(name='SnowWet',
                authors='OpenAlea Consortium (wralea authors)',
                description='water in liquid state in the snow cover',
                category='',
                nodemodule='Snowwet',
                nodeclass='model_snowwet',
                inputs=[{'name': 'Swet_t1', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'precip', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'Snowaccu', 'interface': IFloat, 'value': 0.0}, {'name': 'Mrf', 'interface': IFloat, 'value': 0.0}, {'name': 'M', 'interface': IFloat, 'value': 0.0}, {'name': 'Sdry', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'Swet', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Tavg_model_tavg = Factory(name='Tavg',
                authors='OpenAlea Consortium (wralea authors)',
                description='It simulates the depth of snow cover and recalculate weather data',
                category='',
                nodemodule='Tavg',
                nodeclass='model_tavg',
                inputs=[{'name': 'tmin', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'tmax', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'tavg', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Tempmax_model_tempmax = Factory(name='TempMax',
                authors='OpenAlea Consortium (wralea authors)',
                description='recalculation of maximum temperature',
                category='',
                nodemodule='Tempmax',
                nodeclass='model_tempmax',
                inputs=[{'name': 'Sdepth_cm', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'prof', 'interface': IFloat(min=0, max=1000, step=1.000000), 'value': 0.0}, {'name': 'tmax', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'tminseuil', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'tmaxseuil', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'tmaxrec', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Tempmin_model_tempmin = Factory(name='TempMin',
                authors='OpenAlea Consortium (wralea authors)',
                description='recalculation of minimum temperature',
                category='',
                nodemodule='Tempmin',
                nodeclass='model_tempmin',
                inputs=[{'name': 'Sdepth_cm', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'prof', 'interface': IFloat(min=0, max=1000, step=1.000000), 'value': 0.0}, {'name': 'tmin', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'tminseuil', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'tmaxseuil', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'tminrec', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




Preciprec_model_preciprec = Factory(name='Preciprec',
                authors='OpenAlea Consortium (wralea authors)',
                description='recalculation of precipitation',
                category='',
                nodemodule='Preciprec',
                nodeclass='model_preciprec',
                inputs=[{'name': 'Sdry_t1', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'Sdry', 'interface': IFloat(min=0, max=500, step=1.000000), 'value': 0.0}, {'name': 'Swet', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'Swet_t1', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'Sdepth_t1', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'Sdepth', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'Mrf', 'interface': IFloat, 'value': 0.0}, {'name': 'precip', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 0.0}, {'name': 'Snowaccu', 'interface': IFloat, 'value': 0.0}, {'name': 'rho', 'interface': IFloat, 'value': 100}],
                outputs=[{'name': 'preciprec', 'interface': IFloat(min=0, max=500, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




