# -*- coding: utf-8 -*-
__revision__ = "$Id: setup.py 2249 2010-02-08 17:27:37Z cokelaer $"

import sys
import os

from setuptools import setup, find_packages

# find version number in src/openalea/core/version.py
version = '1.0.0'

name = 'SQ_Energy_Balance'

pkgs = find_packages('.')
packages = pkgs
package_dir = {'':'.'}

#setup_requires = ['openalea.deploy']
#install_requires = []

setup(
    # Meta data (no edition needed if you correctly defined the variables above)
    name=name,
    version=version,
    keywords = 'CropML, OpenAlea',	
    
    # package installation
    packages= packages,	
    package_dir= package_dir,
    
    entry_points = {
            "wralea": [ "SQ_Energy_Balance = SQ_Energy_Balance",
            ]
            },

    )


