package runtime

import "encoding/json"

func Marshal(value any) ([]byte, error) {
	return json.Marshal(value)
}

func Unmarshal(data []byte, target any) error {
	return json.Unmarshal(data, target)
}

func Decode[T any](data []byte) (T, error) {
	var value T
	err := json.Unmarshal(data, &value)
	return value, err
}
