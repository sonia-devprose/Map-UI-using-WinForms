namespace MapsWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webView21.EnsureCoreWebView2Async(null);
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            // Empty
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Ensure CoreWebView2 is ready
            await webView21.EnsureCoreWebView2Async(null);

            // Load HTML content with Leaflet.js and OpenStreetMap
            string htmlContent = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Interactive Map</title>
                    <meta charset='utf-8' />
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <link rel='stylesheet' href='https://unpkg.com/leaflet/dist/leaflet.css' />
                    <style>
                        #map { height: 100vh; }
                    </style>
                </head>
                <body>
                    <div id='map'></div>
                    <script src='https://unpkg.com/leaflet/dist/leaflet.js'></script>
                    <script>
                        var map = L.map('map').setView([51.505, -0.09], 13);
                        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                            attribution: '&copy; OpenStreetMap contributors'
                        }).addTo(map);

                        // Function to handle map panning
                        function panMap(dx, dy) {
                            map.panBy([dx, dy], { animate: true });
                        }

                        // Function to handle map zooming
                        function zoomMap(zoomFactor) {
                            map.setZoom(map.getZoom() + zoomFactor);
                        }
                    </script>
                </body>
                </html>
            ";
            // Navigate to the HTML content with Leaflet.js and OpenStreetMap
            webView21.CoreWebView2.NavigateToString(htmlContent);
        }


        // Method to pan the map by a specified amount (dx, dy)
        private async Task PanMap(int dx, int dy)
        {
            await webView21.CoreWebView2.ExecuteScriptAsync($"panMap({dx}, {dy})");
        }

        // Method to zoom the map by a specified factor (zoomFactor)
        private async Task ZoomMap(int zoomFactor)
        {
            await webView21.CoreWebView2.ExecuteScriptAsync($"zoomMap({zoomFactor})");
        }

        // Example usage:
        private async void panLeftButton_Click(object sender, EventArgs e)
        {
            await PanMap(-50, 0); // Pan map 50 pixels to the left
        }

        private async void panRightButton_Click(object sender, EventArgs e)
        {
            await PanMap(50, 0); // Pan map 50 pixels to the right
        }

        private async void zoomInButton_Click(object sender, EventArgs e)
        {
            await ZoomMap(1); // Zoom in by 1 level
        }

        private async void zoomOutButton_Click(object sender, EventArgs e)
        {
            await ZoomMap(-1); // Zoom out by 1 level
        }

    }
}


