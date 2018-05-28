export class DigitalFilter {
    constructor(private fieldName: string, public minValue: number, public maxValue: number) {}

    public filter = (items: any[]) => {
        const filtered = items.filter(
            (value) => value[this.fieldName] >= this.minValue && value[this.fieldName] <= this.maxValue,
        )

        return filtered
    }
}
