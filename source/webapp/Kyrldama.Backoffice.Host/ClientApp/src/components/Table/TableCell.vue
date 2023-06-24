<template>
  <td ref="cell" class="rvo-table-cell" :class="{'rvo-stickycol': sticky}" :style="{left: position}">
    <div class="rvo-table-cell-content">
      <slot></slot>
    </div>
  </td>
</template>

<script setup>
import { onMounted, ref, nextTick, onUpdated } from 'vue';

const props = defineProps({
  sticky: {
    type: Boolean,
    default: false,
  },
});

const cell = ref(null)
const position = ref(0)

onMounted(async () => {
    var parent = getParent(cell.value);
    var l = cell.value.getBoundingClientRect().left - parent.getBoundingClientRect().left;
    if (props.sticky)
        position.value = l + 'px';
});

function getParent(element)
{
    if (element.id == "table")
        return element;
    return getParent(element.parentElement);
}

</script>