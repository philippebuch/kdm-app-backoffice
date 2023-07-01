<template>
  <div id="app">
    <header id="rvo-header">
      <div class="rvo-section">
        <div id="rvo-header-left">
          <nav id="rvo-mainnav" role="navigation">
            <button id="rvo-mainnav-trigger"><span></span><span></span><span></span></button>
            <ul>
              <li><a class="rvo-current rvo-icon-analysis">Entitées Template</a>
              </li>
            </ul>
          </nav>
        </div>
        <div id="rvo-header-center">
          <nav id="rvo-topnav" role="navigation">
            <ul>
              <li>
                <a class="rvo-current"><router-link to="/EntityTemplate">Template d'entitées</router-link></a>
              </li>
              <li>
                <a><router-link to="/Entity">Entitées</router-link></a>
              </li>
              <li>
                <a><router-link to="/Prompt">Prompts</router-link></a>
              </li>
            </ul>
          </nav>
        </div>
        <div id="rvo-header-right">
          <div class="rvo-sync rvo-online" data-modal-trigger="sync-online"></div>
          <div id="rvo-user">
            <button class="rvo-has-notif" id="rvo-user-image"><img src="img/avatars/avatar1.png"/>
            </button>
            <nav id="rvo-user-nav">
              <ul>
                <li><b id="rvo-user-name">Han Solo</b></li>
                <li>
                  <div class="rvo-slider rvo-slider-avatar">
                    <button class="rvo-slider-prev"> </button>
                    <div class="rvo-slider-overflow">
                      <div class="rvo-slider-items">
                        <div class="rvo-slider-item rvo-current">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar1.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar2.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar3.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar4.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar5.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar6.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar7.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar8.png"/>
                          </div>
                        </div>
                        <div class="rvo-slider-item">
                          <div class="rvo-slider-item-image"><img src="img/avatars/avatar9.png"/>
                          </div>
                        </div>
                      </div>
                    </div>
                    <button class="rvo-slider-next"></button>
                  </div>
                </li>
                <li><a href=""><b>Mes actions</b><span class="rvo-notif">12</span></a></li>
                <li><a href="">Se deconnecter</a></li>
              </ul>
            </nav>
          </div> 
        </div>
      </div>
    </header>
    <main id="rvo-main" role="main">
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
export default {
  name: 'App',
  components: {
  }
}
</script>

<style>
@import "./assets/css/rvo-core.min.css"
</style>
