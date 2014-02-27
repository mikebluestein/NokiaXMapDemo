using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Nokia.Here.Mapping;

namespace NokiaXMapDemo
{
    [Activity (Label = "NokiaXMapDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity, IFragmentInitListener
    {
        IMap map;
        MapFragment mapFragment;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
    
            SetContentView (Resource.Layout.Main);
    
            mapFragment = FragmentManager.FindFragmentById<MapFragment> (Resource.Id.mapfragment);
            mapFragment.Init (this, this);
        }

        public void OnFragmentInitializationCompleted (InitError error)
        {
            if (error == InitError.None) {
                map = mapFragment.Map;

                double lat = 30.2652233534254;
                double lon = -97.73815460962083;
 
                var geoPolygon = MapFactory.CreateGeoPolygon (new JavaList<Nokia.Here.Common.IGeoCoordinate> {
                    MapFactory.CreateGeoCoordinate (30.2648461170005, -97.7381627734755),
                    MapFactory.CreateGeoCoordinate (30.2648355402574, -97.7381750192576),
                    MapFactory.CreateGeoCoordinate (30.2647791309417, -97.7379872505988),
                    MapFactory.CreateGeoCoordinate (30.2654525150319, -97.7377341711021),
                    MapFactory.CreateGeoCoordinate (30.2654807195004, -97.7377994819399),
                    MapFactory.CreateGeoCoordinate (30.2655089239607, -97.7377994819399),
                    MapFactory.CreateGeoCoordinate (30.2656428950368, -97.738346460207),
                    MapFactory.CreateGeoCoordinate (30.2650364981811, -97.7385709662122),
                    MapFactory.CreateGeoCoordinate (30.2650470749025, -97.7386199493406)
                });

                var mapPolyline = MapFactory.CreateMapPolygon (geoPolygon);
                map.AddMapObject (mapPolyline);

                map.SetCenter (MapFactory.CreateGeoCoordinate (lat, lon, 0.0), MapAnimation.None);
                map.SetZoomLevel (18.0, MapAnimation.None);

                map.MapScheme = MapScheme.SatelliteDay;
            }
        }
    }
}