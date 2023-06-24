<template>
  <th ref="col" class="rvo-table-cell" :class="{'rvo-stickycol': sticky, 'rvo-last': islast }" :style="{left: position}">
    <div class="rvo-table-cell-content">
      <div class="rvo-table-cell-label rvo-fontsize-14">
        <slot></slot>
      </div>
    </div>
  </th>
</template>

<script setup>
import { onMounted, ref, nextTick, onUpdated } from 'vue';

const props = defineProps({
  islast: {
    type: Boolean,
    default: false
  },
  sticky: {
    type: Boolean,
    default: false,
  },
});

const col = ref(null)
const position = ref()

onMounted(async () => {
    var parent = getParent(col.value);
    var l = col.value.getBoundingClientRect().left - parent.getBoundingClientRect().left;
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