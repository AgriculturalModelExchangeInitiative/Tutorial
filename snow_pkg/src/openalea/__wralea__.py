
# This file has been generated at Thu May  6 09:56:17 2021

from openalea.core import *


__name__ = 'Snow'

__editable__ = True
__description__ = 'CropML Model library.'
__license__ = 'CECILL-C'
__url__ = 'http://pycropml.rtfd.org'
__alias__ = []
__version__ = '0.0.1'
__authors__ = 'OpenAlea Consortium'
__institutes__ = 'INRA/CIRAD'
__icon__ = ''


__all__ = ['_149540368', 'TempMax_model_TempMax', 'Tavg_model_Tavg', 'SnowWet_model_SnowWet', 'Refreezing_model_Refreezing', 'TempMin_model_TempMin', 'SnowDepthTrans_model_SnowDepthTrans', 'SnowAccumulation_model_SnowAccumulation', 'SnowMelt_model_SnowMelt', 'SnowDepth_model_SnowDepth', 'SnowDensity_model_SnowDensity', 'Melting_model_Melting', 'Preciprec_model_Preciprec', 'SnowDry_model_SnowDry']



_149540368 = CompositeNodeFactory(name='Snow_wf',
                             description='\n\n\n    Snow model\n    Author: STICS\n    Reference: Snow paper\n    Institution: STICS\n    Abstract: Snow\n',
                             category='',
                             doc='',
                             inputs=[  {  'interface': IInt(min=0, max=366, step=1), 'name': 'jul'},
   {  'interface': IFloat, 'name': 'tmaxseuil'},
   {  'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'tminseuil'},
   {  'interface': IFloat(min=0, max=1000, step=1.000000), 'name': 'prof'},
   {  'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'tmin'},
   {  'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'tmax'},
   {  'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'precip'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry_t1'},
   {  'interface': IFloat, 'name': 'E'},
   {  'interface': IFloat, 'name': 'rho', 'value': 100},
   {  'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Sdepth_t1'},
   {  'interface': IFloat, 'name': 'Pns', 'value': 100.0},
   {  'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'Swet_t1'},
   {  'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Kmin'},
   {  'interface': IFloat(min=0, max=5000, step=1.000000),
      'name': 'Tmf',
      'value': 0.5},
   {  'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'SWrf'},
   {  'interface': IFloat(min=0, max=1000, step=1.000000), 'name': 'tsmax'},
   {  'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'DKmax'},
   {  'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'trmax'},
   {  'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'ps_t1'}],
                             outputs=[  {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'tmaxrec'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'ps'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Mrf'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'tavg'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Swet'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Snowmelt'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Snowaccu'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdepth'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'tminrec'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'M'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'preciprec'},
   {  'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdepth_cm'}],
                             elt_factory={  2: ('Snow', 'Melting'),
   3: ('Snow', 'Refreezing'),
   4: ('Snow', 'SnowAccumulation'),
   5: ('Snow', 'SnowDensity'),
   6: ('Snow', 'SnowDepth'),
   7: ('Snow', 'SnowDepthTrans'),
   8: ('Snow', 'SnowDry'),
   9: ('Snow', 'SnowMelt'),
   10: ('Snow', 'SnowWet'),
   11: ('Snow', 'Tavg'),
   12: ('Snow', 'TempMax'),
   13: ('Snow', 'TempMin'),
   14: ('Snow', 'Preciprec')},
                             elt_connections={  17592328L: ('__in__', 16, 4, 0),
   17592352L: ('__in__', 15, 3, 2),
   17592376L: ('__in__', 14, 3, 1),
   17592400L: ('__in__', 13, 2, 3),
   17592424L: ('__in__', 12, 5, 3),
   17592448L: ('__in__', 12, 10, 0),
   17592472L: ('__in__', 11, 7, 1),
   17592496L: ('__in__', 10, 6, 1),
   17592520L: ('__in__', 9, 6, 4),
   17592544L: ('__in__', 8, 6, 3),
   17592568L: ('__in__', 7, 8, 0),
   17592592L: ('__in__', 6, 10, 1),
   17592616L: ('__in__', 4, 11, 0),
   17592640L: ('__in__', 5, 11, 1),
   17592664L: ('__in__', 3, 12, 1),
   17592688L: ('__in__', 5, 12, 2),
   17592712L: ('__in__', 2, 12, 3),
   17592736L: ('__in__', 1, 12, 4),
   17592760L: ('__in__', 4, 13, 2),
   17592784L: ('__in__', 3, 13, 1),
   17592808L: ('__in__', 2, 13, 3),
   17592832L: ('__in__', 1, 13, 4),
   17592856L: ('__in__', 0, 2, 0),
   17592880L: (7, 0, '__out__', 12),
   17592904L: (14, 0, '__out__', 11),
   17592928L: (2, 0, '__out__', 10),
   17592952L: (13, 0, '__out__', 9),
   17592976L: (6, 0, '__out__', 8),
   17593000L: (8, 0, '__out__', 7),
   17593024L: (4, 0, '__out__', 6),
   17593048L: (9, 0, '__out__', 5),
   17593072L: (10, 0, '__out__', 4),
   17593096L: (11, 0, '__out__', 3),
   17593120L: (3, 0, '__out__', 2),
   17593144L: (5, 0, '__out__', 1),
   17593168L: (12, 0, '__out__', 0),
   17593528L: (4, 0, 14, 8),
   17593552L: (3, 0, 14, 6),
   17593576L: (6, 0, 14, 5),
   17593600L: (10, 0, 14, 2),
   17593624L: (8, 0, 14, 1),
   17593648L: (11, 0, 3, 0),
   17593672L: (11, 0, 2, 4),
   17593696L: (4, 0, 8, 1),
   17593720L: (8, 0, 10, 5),
   17593744L: (2, 0, 8, 3),
   17593768L: (7, 0, 12, 0),
   17593792L: (7, 0, 13, 0),
   17593816L: (9, 0, 6, 0),
   17593840L: (2, 0, 10, 4),
   17593864L: (3, 0, 8, 2),
   17593888L: (5, 0, 9, 0),
   17593912L: (3, 0, 10, 3),
   17593936L: (4, 0, 10, 2),
   17593960L: (6, 0, 7, 0),
   17593984L: (4, 0, 6, 2),
   17594008L: ('__in__', 9, 14, 9),
   17594032L: ('__in__', 10, 14, 4),
   17594056L: ('__in__', 12, 14, 3),
   17594080L: ('__in__', 7, 14, 0),
   17594104L: ('__in__', 6, 14, 7),
   17594128L: ('__in__', 14, 2, 1),
   17594152L: ('__in__', 7, 5, 2),
   17594176L: ('__in__', 10, 5, 1),
   17594200L: ('__in__', 19, 5, 0),
   17594224L: ('__in__', 5, 4, 1),
   17594248L: ('__in__', 18, 4, 2),
   17594272L: ('__in__', 17, 2, 2),
   17594296L: ('__in__', 6, 4, 3)},
                             elt_data={  2: {  'block': False,
         'caption': 'Melting',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   3: {  'block': False,
         'caption': 'Refreezing',
         'delay': 0,
         'hide': True,
         'id': 3,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   4: {  'block': False,
         'caption': 'SnowAccumulation',
         'delay': 0,
         'hide': True,
         'id': 4,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   5: {  'block': False,
         'caption': 'SnowDensity',
         'delay': 0,
         'hide': True,
         'id': 5,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   6: {  'block': False,
         'caption': 'SnowDepth',
         'delay': 0,
         'hide': True,
         'id': 6,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   7: {  'block': False,
         'caption': 'SnowDepthTrans',
         'delay': 0,
         'hide': True,
         'id': 7,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   8: {  'block': False,
         'caption': 'SnowDry',
         'delay': 0,
         'hide': True,
         'id': 8,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   9: {  'block': False,
         'caption': 'SnowMelt',
         'delay': 0,
         'hide': True,
         'id': 9,
         'lazy': True,
         'port_hide_changed': set([]),
         'posx': 0,
         'posy': 0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   10: {  'block': False,
          'caption': 'SnowWet',
          'delay': 0,
          'hide': True,
          'id': 10,
          'lazy': True,
          'port_hide_changed': set([]),
          'posx': 0,
          'posy': 0,
          'priority': 0,
          'use_user_color': True,
          'user_application': None,
          'user_color': None},
   11: {  'block': False,
          'caption': 'Tavg',
          'delay': 0,
          'hide': True,
          'id': 11,
          'lazy': True,
          'port_hide_changed': set([]),
          'posx': 0,
          'posy': 0,
          'priority': 0,
          'use_user_color': True,
          'user_application': None,
          'user_color': None},
   12: {  'block': False,
          'caption': 'TempMax',
          'delay': 0,
          'hide': True,
          'id': 12,
          'lazy': True,
          'port_hide_changed': set([]),
          'posx': 0,
          'posy': 0,
          'priority': 0,
          'use_user_color': True,
          'user_application': None,
          'user_color': None},
   13: {  'block': False,
          'caption': 'TempMin',
          'delay': 0,
          'hide': True,
          'id': 13,
          'lazy': True,
          'port_hide_changed': set([]),
          'posx': 0,
          'posy': 0,
          'priority': 0,
          'use_user_color': True,
          'user_application': None,
          'user_color': None},
   14: {  'block': False,
          'caption': 'Preciprec',
          'delay': 0,
          'hide': True,
          'id': 14,
          'lazy': True,
          'port_hide_changed': set([]),
          'posx': 0,
          'posy': 0,
          'priority': 0,
          'use_user_color': True,
          'user_application': None,
          'user_color': None},
   '__in__': {  'block': False,
                'caption': 'In',
                'delay': 0,
                'hide': True,
                'id': 0,
                'lazy': True,
                'port_hide_changed': set([]),
                'posx': 0,
                'posy': 0,
                'priority': 0,
                'use_user_color': True,
                'user_application': None,
                'user_color': None},
   '__out__': {  'block': False,
                 'caption': 'Out',
                 'delay': 0,
                 'hide': True,
                 'id': 1,
                 'lazy': True,
                 'port_hide_changed': set([]),
                 'posx': 0,
                 'posy': 0,
                 'priority': 0,
                 'use_user_color': True,
                 'user_application': None,
                 'user_color': None}},
                             elt_value={  2: [],
   3: [],
   4: [],
   5: [],
   6: [],
   7: [],
   8: [],
   9: [(1, '0.0')],
   10: [],
   11: [],
   12: [],
   13: [],
   14: [],
   '__in__': [],
   '__out__': []},
                             elt_ad_hoc={  2: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   3: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   4: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   5: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   6: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   7: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   8: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   9: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   10: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   11: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   12: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   13: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   14: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [0, 0], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




TempMax_model_TempMax = Factory(name='TempMax',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='TempMax',
                nodeclass='model_TempMax',
                inputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdepth_cm', 'value': 0.0}, {'interface': IFloat(min=0, max=1000, step=1.000000), 'name': 'prof', 'value': 0.0}, {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'tmax', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'tminseuil', 'value': 0.0}, {'interface': IFloat, 'name': 'tmaxseuil', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'tmaxrec'}],
                widgetmodule=None,
                widgetclass=None,
               )




Tavg_model_Tavg = Factory(name='Tavg',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='Tavg',
                nodeclass='model_Tavg',
                inputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'tmin', 'value': 0.0}, {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'tmax', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'tavg'}],
                widgetmodule=None,
                widgetclass=None,
               )




SnowWet_model_SnowWet = Factory(name='SnowWet',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='SnowWet',
                nodeclass='model_SnowWet',
                inputs=[{'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'Swet_t1', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'precip', 'value': 0.0}, {'interface': IFloat, 'name': 'Snowaccu', 'value': 0.0}, {'interface': IFloat, 'name': 'Mrf', 'value': 0.0}, {'interface': IFloat, 'name': 'M', 'value': 0.0}, {'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Swet'}],
                widgetmodule=None,
                widgetclass=None,
               )




Refreezing_model_Refreezing = Factory(name='Refreezing',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='Refreezing',
                nodeclass='model_Refreezing',
                inputs=[{'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'tavg', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Tmf', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'SWrf', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Mrf'}],
                widgetmodule=None,
                widgetclass=None,
               )




TempMin_model_TempMin = Factory(name='TempMin',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='TempMin',
                nodeclass='model_TempMin',
                inputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdepth_cm', 'value': 0.0}, {'interface': IFloat(min=0, max=1000, step=1.000000), 'name': 'prof', 'value': 0.0}, {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'tmin', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'tminseuil', 'value': 0.0}, {'interface': IFloat, 'name': 'tmaxseuil', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'tminrec'}],
                widgetmodule=None,
                widgetclass=None,
               )




SnowDepthTrans_model_SnowDepthTrans = Factory(name='SnowDepthTrans',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='SnowDepthTrans',
                nodeclass='model_SnowDepthTrans',
                inputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdepth', 'value': 0.0}, {'interface': IFloat, 'name': 'Pns', 'value': 100.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdepth_cm'}],
                widgetmodule=None,
                widgetclass=None,
               )




SnowAccumulation_model_SnowAccumulation = Factory(name='SnowAccumulation',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='SnowAccumulation',
                nodeclass='model_SnowAccumulation',
                inputs=[{'interface': IFloat(min=0, max=1000, step=1.000000), 'name': 'tsmax', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'tmax', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'trmax', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'precip', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Snowaccu'}],
                widgetmodule=None,
                widgetclass=None,
               )




SnowMelt_model_SnowMelt = Factory(name='SnowMelt',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='SnowMelt',
                nodeclass='model_SnowMelt',
                inputs=[{'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'ps', 'value': 0.0}, {'interface': IFloat, 'name': 'M', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Snowmelt'}],
                widgetmodule=None,
                widgetclass=None,
               )




SnowDepth_model_SnowDepth = Factory(name='SnowDepth',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='SnowDepth',
                nodeclass='model_SnowDepth',
                inputs=[{'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'Snowmelt', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Sdepth_t1', 'value': 0.0}, {'interface': IFloat, 'name': 'Snowaccu', 'value': 0.0}, {'interface': IFloat, 'name': 'E', 'value': 0.0}, {'interface': IFloat, 'name': 'rho', 'value': 100}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdepth'}],
                widgetmodule=None,
                widgetclass=None,
               )




SnowDensity_model_SnowDensity = Factory(name='SnowDensity',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='SnowDensity',
                nodeclass='model_SnowDensity',
                inputs=[{'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'ps_t1', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Sdepth_t1', 'value': 0.0}, {'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry_t1', 'value': 0.0}, {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'Swet_t1', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'ps'}],
                widgetmodule=None,
                widgetclass=None,
               )




Melting_model_Melting = Factory(name='Melting',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='Melting',
                nodeclass='model_Melting',
                inputs=[{'interface': IInt(min=0, max=366, step=1), 'name': 'jul', 'value': 0}, {'interface': IFloat(min=0, max=1, step=1.000000), 'name': 'Tmf', 'value': 0.5}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'DKmax', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Kmin', 'value': 0.0}, {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'tavg', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'M'}],
                widgetmodule=None,
                widgetclass=None,
               )




Preciprec_model_Preciprec = Factory(name='Preciprec',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='Preciprec',
                nodeclass='model_Preciprec',
                inputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry_t1', 'value': 0.0}, {'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry', 'value': 0.0}, {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'Swet', 'value': 0.0}, {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'Swet_t1', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Sdepth_t1', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'Sdepth', 'value': 0.0}, {'interface': IFloat, 'name': 'Mrf', 'value': 0.0}, {'interface': IFloat(min=0, max=5000, step=1.000000), 'name': 'precip', 'value': 0.0}, {'interface': IFloat, 'name': 'Snowaccu', 'value': 0.0}, {'interface': IFloat, 'name': 'rho', 'value': 100}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'preciprec'}],
                widgetmodule=None,
                widgetclass=None,
               )




SnowDry_model_SnowDry = Factory(name='SnowDry',
                authors='OpenAlea Consortium (wralea authors)',
                description='-',
                category='Unclassified',
                nodemodule='SnowDry',
                nodeclass='model_SnowDry',
                inputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry_t1', 'value': 0.0}, {'interface': IFloat, 'name': 'Snowaccu', 'value': 0.0}, {'interface': IFloat, 'name': 'Mrf', 'value': 0.0}, {'interface': IFloat, 'name': 'M', 'value': 0.0}],
                outputs=[{'interface': IFloat(min=0, max=500, step=1.000000), 'name': 'Sdry'}],
                widgetmodule=None,
                widgetclass=None,
               )




