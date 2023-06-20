const express = require('express');
const jsonSrc = require(__dirname + '/data/locals.json')
const jsonIcon = require(__dirname + '/src/icons/selection.json')
const app = express();

// HTML templating (with Pug)
// ----------------------------
app.set('view engine', 'pug');
app.set('views', __dirname + '/src/views')

// Pretty HTML (otherwise html is compiled in one line)
app.locals.pretty = true

// Routing
// ----------------------------
function getPage(req, res, pageName){
  res.render(pageName, {
      jsondata: jsonSrc,
      strings: jsonSrc.global,
      pages: jsonSrc.pages,
      jsonicons: jsonIcon.icons.sort(),
      mode: req.query.mode
  })
}
app.get('/', function (req, res) {getPage(req, res, 'index')})
app.get('/index', function (req, res) {getPage(req, res, 'index')})
app.get('/uikit/', function (req, res) {getPage(req, res, 'uikit/index')})
app.get('/uikit/index', function (req, res) {getPage(req, res, 'uikit/index')})
app.get('/uikit/howto', function (req, res) {getPage(req, res, 'uikit/index')})
app.get('/uikit/masterpage', function (req, res) {getPage(req, res, 'uikit/masterpage')})
app.get('/uikit/layout', function (req, res) {getPage(req, res, 'uikit/layout')})
app.get('/uikit/atoms', function (req, res) {getPage(req, res, 'uikit/atoms')})
app.get('/uikit/components', function (req, res) {getPage(req, res, 'uikit/components')})
app.get('/uikit/pages', function (req, res) {getPage(req, res, 'uikit/pages')})

app.get('/landingpage', function (req, res) {getPage(req, res, 'landingpage')})
app.get('/lettrage', function (req, res) {getPage(req, res, 'lettrage')})
app.get('/lettrage-rapprochement', function (req, res) {getPage(req, res, 'lettrage-rapprochement')})
app.get('/lettrage-rapprochement-recap', function (req, res) {getPage(req, res, 'lettrage-rapprochement-recap')})
app.get('/lettrage-recapitulatif', function (req, res) {getPage(req, res, 'lettrage-recapitulatif')})
app.get('/lettrage-compte-attente', function (req, res) {getPage(req, res, 'lettrage-compte-attente')})
app.get('/lettrage-gestion-soldes-avoir', function (req, res) {getPage(req, res, 'lettrage-gestion-soldes-avoir')})
app.get('/lettrage-gestion-soldes-cheque', function (req, res) {getPage(req, res, 'lettrage-gestion-soldes-cheque')})
app.get('/lettrage-gestion-documentaire', function (req, res) {getPage(req, res, 'lettrage-gestion-documentaire')})
app.get('/lettrage-correspondance-client', function (req, res) {getPage(req, res, 'lettrage-correspondance-client')})
app.get('/preparation-vente', function (req, res) {getPage(req, res, 'preparation-vente')})
app.get('/preparation-en-cours', function (req, res) {getPage(req, res, 'preparation-en-cours')})
app.get('/preparation-vente-b2c', function (req, res) {getPage(req, res, 'preparation-vente-b2c')})
app.get('/analyse-vente', function (req, res) {getPage(req, res, 'analyse-vente')})
app.get('/analyse-vente-tableau', function (req, res) {getPage(req, res, 'analyse-vente-tableau')})
app.get('/vente-b2c-affecter-vehicules', function (req, res) {getPage(req, res, 'vente-b2c-affecter-vehicules')})
app.get('/vente-b2c-gerer-vehicules', function (req, res) {getPage(req, res, 'vente-b2c-gerer-vehicules')})
app.get('/transport', function (req, res) {getPage(req, res, 'transport')})
app.get('/transport-en-attente', function (req, res) {getPage(req, res, 'transport-en-attente')})
app.get('/transport-suivi', function (req, res) {getPage(req, res, 'transport-suivi')})
app.get('/transport-en-souffrance', function (req, res) {getPage(req, res, 'transport-en-souffrance')})
app.get('/transport-suspendus', function (req, res) {getPage(req, res, 'transport-suspendus')})
app.get('/vente-pro-cooperation', function (req, res) {getPage(req, res, 'vente-pro-cooperation')})
app.get('/vente-pro-repasse', function (req, res) {getPage(req, res, 'vente-pro-repasse')})
app.get('/vente-pro-rachat-garage', function (req, res) {getPage(req, res, 'vente-pro-rachat-garage')})
app.get('/vente-pro-immediate', function (req, res) {getPage(req, res, 'vente-pro-immediate')})
app.get('/vente-pro-acheteurs', function (req, res) {getPage(req, res, 'vente-pro-acheteurs')})


// Serving
// ----------------------------

// Set the static assets directory
app.use(express.static(__dirname + '/build'))

// Serving app on http://localhost:xxxx
app.listen(3001, () => {
  console.log('Listening on port http://localhost:3001');
});