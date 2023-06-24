<template>
  <div class="rvo-section">
    <div class="rvo-page-section rvo-margin-t15">
      <div class="rvo-table-scroll">
        <table id="table" class="rvo-table rvo-bordered rvo-padding-m" v-if="loaded">
          <thead class="rvo-table-topheader">
            <tr class="rvo-table-row">
              <TableHeader :sticky="true" :islast="true" colspan="3">Template d'entitées</TableHeader>
              <TableHeader :islast="true" colspan="3">Prompt</TableHeader>
            </tr>
          </thead>
          <thead class="rvo-table-header">
            <tr class="rvo-table-row">
              <TableHeader :sticky="true" ></TableHeader>
              <TableHeader :sticky="true" >Id</TableHeader>
              <TableHeader :sticky="true" :islast="true">Label</TableHeader>
              
              <TableHeader ></TableHeader>
              <TableHeader >Id</TableHeader>
              <TableHeader :islast="true">Content</TableHeader>
            </tr>
          </thead>
          <tbody class="rvo-table-body">
            <EntityTemplateListElement v-for="element in state.list" :key="element.id" :entityTemplate="element"/>
          </tbody>
        </table>
      </div>
    </div>
    <div class="rvo-page-actions">
      <button class="rvo-button" type="button">Valider</button>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";

import TableHeader from "components/Table/TableHeader.vue";


import EntityTemplateStore from "stores/entityTemplateStore.js";
import EntityTemplateListElement from 'components/EntityTemplate/EntityTemplateListElement.vue'

let store = new EntityTemplateStore();

const state = ref(store.state);
const loaded = ref(false);

onMounted(async () => {
  await load();

  loaded.value = true;
});

async function load() {
  await store.getList();
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
