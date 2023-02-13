function dateTime(value, type) {
  if (!value) {
    return
  }
  let temp = new Date(value)
  if (!isValidDate(temp) && typeof value == 'string') {
    temp = new Date(parseFloat(value))
  }
  return i18n.d(temp, type || 'long')
}
function time(value, type) {
  if (!value) {
    return
  }
  let temp = new Date(value)
  if (!isValidDate(temp) && typeof value == 'string') {
    temp = new Date(parseFloat(value))
  }
  return i18n.d(temp, type || 'time')
}
function isValidDate(d) {
  return d instanceof Date
}

function timeFormat(s) {
  if (!s) return ''
  let ms = s % 1000
  s = (s - ms) / 1000
  let secs = (s % 60) + ''
  s = (s - secs) / 60
  let mins = (s % 60) + ''
  let hrs = (s - mins) / 60 + ''

  return (
    hrs.padStart(2, 0) + ':' + mins.padStart(2, 0) + ':' + secs.padStart(2, 0)
  )
}

let filter = {
  timeFormat,
  dateTime,
}
export default filter
