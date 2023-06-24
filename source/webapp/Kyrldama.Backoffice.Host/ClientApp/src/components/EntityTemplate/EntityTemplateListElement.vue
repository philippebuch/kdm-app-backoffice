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
          <a href="#"> {{entityTemplate.id}}</a>
        </div>
    </TableCell>
    <TableCell class="rvo-stickycol rvo-last" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12">{{entityTemplate.label}}</div>
    </TableCell>


    <!-- <TableCell class="rvo-stickycol" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12">
          {{entityTemplate.creationDate}}
        </div>
    </TableCell>
    <TableCell class="rvo-align-center rvo-last" :sticky="true">
        <div class="rvo-table-cell-label rvo-fontsize-12">{{entityTemplate.updateDate}}</div>
    </TableCell> -->

    <td class="rvo-table-cell">
      <div class="rvo-table-cell-content">
        <div class="rvo-menu-container">
          <button
            class="rvo-button-mini rvo-icon-history rvo-shadowed"
            type="button"
            title="Historique des modifications"
            data-menu-trigger="07gfjxaxx"
          ></button>
          <div class="rvo-menu rvo-on-bottomright" data-menu="07gfjxaxx">
            <div class="rvo-menu-content">
              <div class="rvo-history">
                <div class="rvo-history-title">Px argus</div>
                <div class="rvo-history-row">
                  <div class="rvo-history-name">O.Petit</div>
                  <div class="rvo-history-date">06/04/22</div>
                  <div class="rvo-history-modif">12755</div>
                  <div class="rvo-history-check"></div>
                </div>
              </div>
              <div class="rvo-history">
                <div class="rvo-history-title">Px réserve</div>
                <div class="rvo-history-row">
                  <div class="rvo-history-name">O.Petit</div>
                  <div class="rvo-history-date">06/04/22</div>
                  <div class="rvo-history-modif">13200</div>
                  <div class="rvo-history-check"></div>
                </div>
                <div class="rvo-history-row">
                  <div class="rvo-history-name">B; de Chartres</div>
                  <div class="rvo-history-date">17/05/22</div>
                  <div class="rvo-history-modif">13000</div>
                  <div class="rvo-history-check">
                    <span class="rvo-icon-check"></span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </td>
    <TableCell>
        <div class="rvo-table-cell-label rvo-fontsize-12">{{entityTemplate.prompt.id}}</div>
    </TableCell>
    <TableCell class="rvo-last rvo-minwidth-200">
        <div class="rvo-table-cell-label rvo-fontsize-12" :title="entityTemplate.prompt.content">{{entityTemplate.prompt.content.slice(0,100)}}...</div>
    </TableCell>
  </tr>
</template>

<script setup>
import TableCell from "components/Table/TableCell.vue";

const props = defineProps({
  entityTemplate: Object
})
</script>