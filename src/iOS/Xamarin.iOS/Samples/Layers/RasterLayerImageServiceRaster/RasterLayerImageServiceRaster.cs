// Copyright 2017 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an 
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific 
// language governing permissions and limitations under the License.

using System;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Rasters;
using Esri.ArcGISRuntime.UI.Controls;
using Foundation;
using UIKit;

namespace ArcGISRuntime.Samples.RasterLayerImageServiceRaster
{
    [Register("RasterLayerImageServiceRaster")]
    [ArcGISRuntime.Samples.Shared.Attributes.Sample(
        "ArcGIS raster layer (service)",
        "Layers",
        "Add a raster layer from an image service to a map.",
        "")]
    public class RasterLayerImageServiceRaster : UIViewController
    {
        // Create and hold a reference to the MapView.
        private MapView _myMapView;

        public RasterLayerImageServiceRaster()
        {
            Title = "ArcGIS raster layer (service)";
        }

        public override void LoadView()
        {
            _myMapView = new MapView();
            _myMapView.TranslatesAutoresizingMaskIntoConstraints = false;

            View = new UIView();
            View.AddSubviews(_myMapView);

            _myMapView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
            _myMapView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
            _myMapView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            _myMapView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Initialize();
        }

        private void Initialize()
        {
            // Create new map with the dark gray canvas basemap.
            Map myMap = new Map(Basemap.CreateDarkGrayCanvasVector());

            // Create a Uri to the image service raster.
            Uri uri = new Uri("https://gis.ngdc.noaa.gov/arcgis/rest/services/bag_hillshades/ImageServer");

            // Create new image service raster from the Uri.
            ImageServiceRaster imageServiceRaster = new ImageServiceRaster(uri);

            // Create a new raster layer from the image service raster.
            RasterLayer rasterLayer = new RasterLayer(imageServiceRaster);

            // Add the raster layer to the maps layer collection.
            myMap.Basemap.BaseLayers.Add(rasterLayer);

            // Assign the map to the map view.
            _myMapView.Map = myMap;

            // zoom in to the San Francisco Bay.
            _myMapView.SetViewpointCenterAsync(new MapPoint(-13643095.660131, 4550009.846004, SpatialReferences.WebMercator), 100000);
        }
    }
}