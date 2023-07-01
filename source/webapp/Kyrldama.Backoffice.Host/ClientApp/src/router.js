// 1. Définissez les composants de route.
// Ces derniers peuvent être importés depuis d'autre fichier
const Foo = { template: '<div>foo</div>' }
const Bar = { template: '<div>bar</div>' }
import EntityTemplateList from './components/EntityTemplate/EntityTemplateList.vue'
import EntityList from './components/Entity/EntityList.vue'
import PromptList from './components/Prompt/PromptList.vue'
// 2. Définissez des routes.
// Chaque route doit correspondre à un composant. Le « composant » peut
// soit être un véritable composant créé via `Vue.extend()`, ou juste un
// objet d'options.
// Nous parlerons plus tard des routes imbriquées.
const routes = [
  { path: '/EntityTemplate', component: EntityTemplateList },
  { path: '/Entity', component: EntityList },
  { path: '/Prompt', component: PromptList }
]

// 3. Créez l'instance du routeur et passez l'option `routes`.
// Vous pouvez également passer des options supplémentaires,
// mais nous allons faire simple pour l'instant.

export default routes;