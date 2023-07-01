<template>
  <tr class="rvo-table-row">
    <TableCell class="rvo-table-cell-button" :sticky="true">
        <button
          class="rvo-button-mini rvo-icon-bookmark-fill"
          type="button"
          title="Marquer la ligne"
        ></button>
    </TableCell>
    <TableCell class="rvo-table-cell-button" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12 rvo-wspace-nowrap">
          <a href="#"> {{entity.id}}</a>
        </div>
    </TableCell>
    <TableCell class="rvo-stickycol" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12">{{entity.label}}</div>
    </TableCell>
    <TableCell class="rvo-stickycol rvo-last" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12">{{entity.content}}</div>
    </TableCell>


    <!-- <TableCell class="rvo-stickycol" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12">
          {{entityTemplate.creationDate}}
        </div>
    </TableCell>
    <TableCell class="rvo-align-center rvo-last" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12">{{entityTemplate.updateDate}}</div>
    </TableCell> -->
  </tr>
</template>

<script setup>
import TableCell from "components/Table/TableCell.vue";

const props = defineProps({
  entity: Object
})
</script>